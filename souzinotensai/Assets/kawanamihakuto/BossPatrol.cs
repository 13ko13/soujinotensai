﻿using UnityEngine;


public class BossPatrol : MonoBehaviour
{

    // 生成したいもの（今回は汚れ）
    [SerializeField] private GameObject dirt;
    [SerializeField] private int widthtile = 2;
    [SerializeField] private int heighttile = 2;
    public float moveInterval = 1f;         //移動時間間隔
    public float moveDistance = 1f;         // 1マス分の距離
    public float checkWallRadius = 1.0f;    //壁判定用の判定半径
    public float checkEnemyRadius = 2.0f;   //敵判定用のサークル半径
    private float checkDirtRadius = 0.1f; 　//判定用のサークルの半径
    private float gridsize = 1f; //1マス
    float  dirtUpdate;
    
    private float timer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        dirtUpdate = 0;
        timer = moveInterval;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            FindDirt();
            TryMoveToNextGrid();      // グリッド移動
            timer = moveInterval;
        }
    }

    public void FindDirt()
    {
        Vector2 origin = transform.position;

        //オフセットを計算する
        float xStart = -((widthtile -1)  / 2);
        float yStart = -((heighttile - 1) / 2);

        for(int y = 0; y < heighttile; y++)
        {
            for(int x = 0; x < widthtile; x++)
            {
                Vector2 offset = new Vector2((xStart + x) * gridsize, (yStart + y) * gridsize);
                Vector2 cellsenter = origin+ offset;

                if(!IsDirtAtPosition(cellsenter))
                {
                    
                    SpawnDirtFromCollider();  // Bossのサイズに応じて汚れを生成
                }
            }
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
                    dirtUpdate++; //汚れの数を記録
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

        ShuffleArray(directions);

        foreach (Vector3 dir in directions)
        {
            Vector3 nextPos = transform.position + dir * moveDistance;

            if (!IsWallAtPosition(nextPos) == false || !IsEnemyAtPosition(nextPos) == false)
            {
                transform.position = nextPos;
                return;
            }
            // 全方向壁なら移動しない
            //全方向敵なら移動しない
        }
    }

    bool IsWallAtPosition(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, checkWallRadius, LayerMask.GetMask("Wall"));
        return hit != null;
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

    bool IsEnemyAtPosition(Vector2 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, checkEnemyRadius, LayerMask.GetMask("Enemy"));
        return hit != null;
    }

    bool IsDirtAtPosition(Vector2 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, checkDirtRadius, LayerMask.GetMask("dirt"));
        return hit != null;
    }

    void DirtUpdateFunction()
    {
        Destroy(gameObject);
    }
}
