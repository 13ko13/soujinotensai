using UnityEngine;


public class BossProgress: MonoBehaviour
{
    // 生成したいもの（今回は汚れ）
    [SerializeField] private GameObject dirt;
    public float moveInterval = 1f;     // 次のマスに動くまでの時間
    public float moveDistance = 1f;     // 1マス分の距離
    public float checkRadius = 0.2f;    // 壁判定用の判定半径

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
            SpawnDirtFromCollider();  // Bossのサイズに応じて汚れを生成
            TryMoveToNextGrid();      // グリッド移動
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
        Vector2Int tileSize = new Vector2Int
        (
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

        ShuffleArray(directions);

        foreach (Vector3 dir in directions)
        {
            Vector3 nextPos = transform.position + dir * moveDistance;
            Debug.Log(nextPos);

            if (!IsWallAtPosition(nextPos) && !IsEnemyAtPosition(nextPos))
            {
                transform.position = nextPos;
                return;
            }
            else
            {
                nextPos = Vector3.zero;
                Debug.Log("リセット");
                ShuffleArray(directions);
                nextPos = transform.position + dir * moveDistance;
                transform.position = nextPos;

            }

        }
        // 全方向壁なら移動しない
    }

    bool IsWallAtPosition(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, checkRadius, LayerMask.GetMask("Wall"));
        return hit != null;
    }

    bool IsEnemyAtPosition(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, checkRadius, LayerMask.GetMask("Enemy"));
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
}
