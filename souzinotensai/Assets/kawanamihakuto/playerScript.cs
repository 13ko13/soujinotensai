using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    [SerializeField] private Sprite[] playerSprites; //�X�v���C�g4��

    bubbleNumDirector _bubbleNumDirector;
    GaugeController _GaugeController;
    GameManager gm;
    public SpriteRenderer SpriteRenderer;
    public GameObject bubblePrefab;
    public Transform firepoit;
    public GameObject[] wall;
    public float speed = 0.1f;
    private float timer;
    public int cleaning = 0;//�|��������(reload�̒l�ɒB�����烊�Z�b�g�����)
    public int reload = 20;//�e�𑝂₷�����̒l
    int bulletsNum = 0;//�c��e��(���̏����Œǉ������)
    int frame=0;

    public GameObject wallRight;
    public GameObject wallLeft;
    public GameObject wallUp;
    public GameObject wallUnder;

    public Vector3 wallXScale;
    public Vector3 wallYScale;
    public Vector3 cullentPos;

    public AudioSource launchSoundSource;//���ʉ�AudioSource
    public AudioSource dirtSound;
    public AudioSource chargeBubble;

    public bool isDie;
    void Start()
    {
        _GaugeController = GameObject.Find("Gauge").GetComponent<GaugeController>();
        _bubbleNumDirector = GameObject.Find("BubbleNumDirector").GetComponent<bubbleNumDirector>();

        SpriteRenderer = GetComponent<SpriteRenderer>();

        isDie = false;
        Debug.Log(wallUnder.transform.position);

        wallXScale = wallRight.transform.localScale;
        wallYScale = wallUnder.transform.localScale;
    }

    void Update()
    {
        frame++;
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameManager.Instance.OnPlayerDeath();
        }

        if (cleaning >= reload)//��萔�����|��������
        {
            Debug.Log("�e��[+1]  �|�����[�^�[���Z�b�g");
            cleaning = 0;//�|���������̃��Z�b�g
            _GaugeController.GaugeNum = 0;
            Debug.Log("�ʂP�����");
            bulletsNum += 1;//�e���P���₷
            _bubbleNumDirector.bNum = bulletsNum;
            ChargeBubbleSound();
        }

        //W���������Ƃ�
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            SpriteRenderer.sprite = playerSprites[0];  //�����
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, 1);
        }
        //S���������Ƃ�
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            SpriteRenderer.sprite = playerSprites[1];  //������
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, -1);
        }
        //A���������Ƃ�
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            SpriteRenderer.sprite = playerSprites[2];  //�E����
            this.GetComponent<Rigidbody2D>().position += new Vector2(-1, 0);
        }
        //D���������Ƃ�
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            SpriteRenderer.sprite = playerSprites[3];  //�E����
            this.GetComponent<Rigidbody2D>().position += new Vector2(1, 0);
        }

        cullentPos = transform.position; //���݂̈ʒu���L��

        if (transform.position.x > wallRight.transform.position.x - wallXScale.x) //�E�̕ǂɂ߂肱�񂾂�
        {
            //�ǂ̒��֖߂�
            cullentPos.x = wallRight.transform.position.x - wallXScale.x;
            cullentPos.z = wallRight.transform.position.z;
            transform.position = cullentPos;
        }
        if (transform.position.x < wallLeft.transform.position.x + wallXScale.x) //���̕ǂɂ߂肱�񂾂�
        {
            //�ǂ̒��֖߂�
            cullentPos.x = wallLeft.transform.position.x + wallXScale.x;
            cullentPos.z = wallLeft.transform.position.z;
            transform.position = cullentPos;
        }
        if (transform.position.y > wallUp.transform.position.y - wallYScale.y) //��̕ǂɂ߂肱�񂾂�
        {
            //�ǂ̒��֖߂�
            cullentPos.y = wallUp.transform.position.y - wallYScale.y;
            cullentPos.z = wallUp.transform.position.z;
            transform.position = cullentPos;
        }
        if (transform.position.y < wallUnder.transform.position.y + wallYScale.y) //���̕ǂɂ߂肱�񂾂�
        {
            Debug.Log("��");
            //�ǂ̒��֖߂�
            cullentPos.y = wallUnder.transform.position.y + wallYScale.y;
            cullentPos.z = wallUnder.transform.position.z;
            transform.position = cullentPos;
        }



        timer += Time.deltaTime;//�^�C�}�[�̎��Ԃ𓮂���

        if (Input.GetKeyDown(KeyCode.Space) && bulletsNum >= 1)
        {
            bulletsNum -= 1;//�c��e�������炷
            _bubbleNumDirector.bNum = bulletsNum;
            Instantiate(bubblePrefab, firepoit.position, transform.rotation);//���𔭎�
            PlayLaunchSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // �G���ǂ����̃^�O���`�F�b�N
        {
            Debug.Log("Enemy");

            Destroy(gameObject);
            isDie = true;

            //SceneManager.LoadScene("GameoverScene");

            
        }

        if (collision.gameObject.CompareTag("dirt"))
        {
            Debug.Log("�|�����[�^�[[+1]");
            cleaning += 1;
            _GaugeController.GaugeNum++;
            PlayDirtSound();
        }

    }

    void PlayLaunchSound()
    {
        //AudioSource�Ō��ʉ����Đ�
        if (launchSoundSource != null)
        {
            launchSoundSource.Play();
        }
        else
        {
            Debug.Log("AudioSource���ݒ肳��Ă��Ȃ�");
        }
    }


    void PlayDirtSound()
    {
        //AudioSource�Ō��ʉ����Đ�
        if (dirtSound != null)
        {
            dirtSound.Play();
        }
        else
        {
            Debug.Log("AudioSource���ݒ肳��Ă��Ȃ�");
        }
    }

    void ChargeBubbleSound()
    {
        if (chargeBubble != null)
        {
            chargeBubble.Play();
        }
    }
}

