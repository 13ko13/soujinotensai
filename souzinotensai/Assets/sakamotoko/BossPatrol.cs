using System.Xml;
using UnityEngine;

public class EnemyInstantGridMove2D : MonoBehaviour
{
    [SerializeField] private GameObject dirt;
    public float moveInterval = 1f;     // 次のマスに動くまでの時間
    public float moveDistance = 1f;     // 1マス分の距離
    public float checkRadius = 0.2f;    // 壁判定用の判定半径

    private float timer;

    void Start()
    {
        
        timer = moveInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            GameObject.Instantiate(dirt,this.transform.position, Quaternion.identity);
            TryMoveToNextGrid();
            timer = moveInterval;
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

            if (!IsWallAtPosition(nextPos))
            {
                // 一瞬で移動
                transform.position = nextPos;
                return;
            }
        }
        // 全方向壁なら移動しない
    }

    bool IsWallAtPosition(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, checkRadius, LayerMask.GetMask("Wall"));
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
