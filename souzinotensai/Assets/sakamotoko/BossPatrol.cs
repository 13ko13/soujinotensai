using UnityEngine;

public class EnemyInstantGridMove2D : MonoBehaviour
{
    public float moveInterval = 1f;     // ���̃}�X�Ɉړ�����܂ł̊Ԋu�i�b�j
    public float moveDistance = 1f;     // 1�}�X�̋����i�P�ʁj

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
            Vector3.up,    // ��
            Vector3.down,  // ��
            Vector3.left,  // ��
            Vector3.right  // �E
        };

        Vector3 chosenDir = directions[Random.Range(0, directions.Length)];

        // ���݈ʒu�ɑI�񂾕�����1�}�X���𑫂��ďu�Ԉړ�
        transform.position += chosenDir * moveDistance;
    }
}
