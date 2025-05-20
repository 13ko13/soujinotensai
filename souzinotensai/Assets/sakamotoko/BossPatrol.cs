using UnityEngine;

public class EnemyInstantGridMove2D : MonoBehaviour
{
    public float moveInterval = 1f;     // 次のマスに移動するまでの間隔（秒）
    public float moveDistance = 1f;     // 1マスの距離（単位）

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
            MoveToNextGrid();
            timer = moveInterval;
        }
    }

    void MoveToNextGrid()
    {
        Vector3[] directions = new Vector3[]
        {
            Vector3.up,    // 上
            Vector3.down,  // 下
            Vector3.left,  // 左
            Vector3.right  // 右
        };

        Vector3 chosenDir = directions[Random.Range(0, directions.Length)];

        // 現在位置に選んだ方向の1マス分を足して瞬間移動
        transform.position += chosenDir * moveDistance;
    }
}
