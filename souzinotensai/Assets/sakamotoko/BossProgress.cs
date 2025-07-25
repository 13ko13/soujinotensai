﻿using UnityEngine;


public class BossProgress2 : MonoBehaviour
{
    // 生成したいもの（今回は汚れ）
    [SerializeField] private GameObject dirt;
    public float moveInterval = 1f;     // 次のマスに動くまでの時間
    public float moveDistance = 1f;     // 1マス分の距離
    public float checkWallRadius = 0.2f;    // 壁判定用の判定半径
    public float checkEnemyRadius = 0.4f;
    Vector3[] dirtPos;

    private float timer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        timer = moveInterval;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            TryMoveToNextGrid();      // グリッド移動
            SpawnDirtFromCollider();  // Bossのサイズに応じて汚れを生成            
            timer = moveInterval;
        }
    }

    void SpawnDirtFromCollider()
    {
        if (boxCollider == null) return;

        // コライダーのサイズとオフセットを取得
        Vector2 size = boxCollider.size;
        Vector2 offset = boxCollider.offset;

        // マス単位の幅と高さ（roundして整数化）
        Vector2Int tileSize = new Vector2Int(
            Mathf.RoundToInt(size.x / moveDistance),
            Mathf.RoundToInt(size.y / moveDistance)
        );

        // 左下を基準とした生成開始位置（中心 + オフセット - 半サイズ）
        Vector3 origin = transform.position + (Vector3)offset - new Vector3(size.x, size.y, 0f) * 0.5f;

        // 各マスに汚れを生成
        for (int x = 0; x < tileSize.x; x++)
        {
            for (int y = 0; y < tileSize.y; y++)
            {
                Vector3 spawnPos = origin + new Vector3(x * moveDistance, y * moveDistance, 0f);
                Instantiate(dirt, spawnPos, Quaternion.identity);
            }
        }
    }

    void TryMoveToNextGrid()
    {
        Vector3[] directions = new Vector3[]
        {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right
        };

        ShuffleArray(directions);  // 毎回ランダム順にする

        foreach (Vector3 dir in directions)
        {
            Vector3 nextPos = transform.position + dir * moveDistance;

            if (!IsWallAtPosition(nextPos) /*&& !IsEnemyAtPosition(nextPos)*/)
            {
                // 壁でも敵でもなければ移動！
                transform.position = nextPos;
                return;
            }
        }

        // 全方向ふさがれてたら何もしない（待機）
    }

    bool IsWallAtPosition(Vector3 position)
    {

        Collider2D hit = Physics2D.OverlapCircle(position, checkWallRadius, LayerMask.GetMask("Wall"));
        return hit != null;
    }

    bool IsEnemyAtPosition(Vector3 position)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, checkEnemyRadius, LayerMask.GetMask("Enemy"));

        foreach (var hit in hits)
        {
            if (hit.gameObject != this.gameObject)
            {
                return true;
            }
        }

        return false;
    }


    void ShuffleArray(Vector3[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            Vector3 temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
