using UnityEngine;


public class BossProgress: MonoBehaviour
{
    // �������������́i����͉���j
    [SerializeField] private GameObject dirt;
    public float moveInterval = 1f;     // ���̃}�X�ɓ����܂ł̎���
    public float moveDistance = 1f;     // 1�}�X���̋���
    public float checkRadius = 0.2f;    // �ǔ���p�̔��蔼�a

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
            SpawnDirtFromCollider();  // Boss�̃T�C�Y�ɉ����ĉ���𐶐�
            TryMoveToNextGrid();      // �O���b�h�ړ�
            timer = moveInterval;
        }
    }

    void SpawnDirtFromCollider()
    {
        if (boxCollider == null) return;

        // �R���C�_�[�̃T�C�Y�ƃI�t�Z�b�g���擾
        Vector2 size = boxCollider.size;
        Vector2 offset = boxCollider.offset;

        // �}�X�P�ʂ̕��ƍ����iround���Đ������j
        Vector2Int tileSize = new Vector2Int
        (
            Mathf.RoundToInt(size.x / moveDistance),
            Mathf.RoundToInt(size.y / moveDistance)
        );

        // ��������Ƃ��������J�n�ʒu�i���S + �I�t�Z�b�g - ���T�C�Y�j
        Vector3 origin = transform.position + (Vector3)offset - new Vector3(size.x, size.y, 0f) * 0.5f;

        // �e�}�X�ɉ���𐶐�
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
                Debug.Log("���Z�b�g");
                ShuffleArray(directions);
                nextPos = transform.position + dir * moveDistance;
                transform.position = nextPos;

            }

        }
        // �S�����ǂȂ�ړ����Ȃ�
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
