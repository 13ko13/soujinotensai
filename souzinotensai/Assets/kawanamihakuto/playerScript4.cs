using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
public class player4 : MonoBehaviour
{
    [SerializeField] private Sprite[] playerSprites; //�X�v���C�g4��

    bubbleNumDirector _bubbleNumDirector;
    GaugeController2 _GaugeController2;
    GameManager gm;
    public SpriteRenderer SpriteRenderer;
    public GameObject bubblePrefab2;
    public Transform firepoit;
    public GameObject[] wall;
    public float speed = 0.1f;
    private float timeBetweenShot = 3.0f;//�����ēx�łĂ�悤�ɂȂ�܂ł̎���
    private float timer;
    public int cleaning = 0;//�|��������(reload�̒l�ɒB�����烊�Z�b�g�����)
    public int reload = 30;//�e�𑝂₷�����̒l
    int bulletsNum = 0;//�c��e��(���̏����Œǉ������)
    int frame=0;

    public Vector3 wallRightSidePos;
    public Vector3 wallLeftSidePos;
    public Vector3 wallUpVerticalPos;
    public Vector3 wallUnderVerticalPos;
    public Vector3 wallThickY;
    public Vector3 wallThicX;

    public Vector3 cullentPos;

    public AudioSource launchSoundSource;//���ʉ�AudioSource
    public AudioSource dirtSound;
    void Start()
    {
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>(); //�Q�[���}�l�[�W���[

        _GaugeController2 = GameObject.Find("Gauge").GetComponent<GaugeController2>();
        _bubbleNumDirector = GameObject.Find("BubbleNumDirector").GetComponent<bubbleNumDirector>();
        wallLeftSidePos = GameObject.Find("wallLeft").transform.position;
        wallRightSidePos = GameObject.Find("wallRight").transform.position;
        wallUpVerticalPos = GameObject.Find("wallUp").transform.position;
        wallUnderVerticalPos = GameObject.Find("wallUnder").transform.position;

        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        frame++;
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameManager.Instance.OnPlayerDeath();
        }

        cullentPos = transform.position;
        if (cleaning >= reload)//��萔�����|��������
        {
            Debug.Log("�e��[+1]  �|�����[�^�[���Z�b�g");
            cleaning = 0;//�|���������̃��Z�b�g
            _GaugeController2.GaugeNum = 0;
            Debug.Log("�ʂP�����");
            bulletsNum += 1;//�e���P���₷
            _bubbleNumDirector.bNum = bulletsNum;
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
            SpriteRenderer.sprite = playerSprites[2];  //������
            this.GetComponent<Rigidbody2D>().position += new Vector2(-1, 0);
        }
        //D���������Ƃ�
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            SpriteRenderer.sprite = playerSprites[3];  //�E����
            this.GetComponent<Rigidbody2D>().position += new Vector2(1, 0);
        }

        if (transform.position.x > wallRightSidePos.x) //�E�̕ǂɂ߂肱�񂾂�
        {
            //�ǂ̒��֖߂�
            cullentPos.x = wallRightSidePos.x;
            transform.position = cullentPos;
        }
        if (transform.position.x < wallLeftSidePos.x) //���̕ǂɂ߂肱�񂾂�
        {
            //�ǂ̒��֖߂�
            cullentPos.x = wallLeftSidePos.x;
            Debug.Log(cullentPos.x);
            transform.position = cullentPos;
        }
        if (transform.position.y > wallUpVerticalPos.y) //��̕ǂɂ߂肱�񂾂�
        {
            //�ǂ̒��֖߂�
            cullentPos.y = wallUpVerticalPos.y;
            transform.position = cullentPos;
        }
        if (transform.position.y < wallUnderVerticalPos.y) //���̕ǂɂ߂肱�񂾂�
        {
            //�ǂ̒��֖߂�
            cullentPos.y = wallUnderVerticalPos.y;
            transform.position = cullentPos;
        }



        timer += Time.deltaTime;//�^�C�}�[�̎��Ԃ𓮂���

        if (Input.GetKeyDown(KeyCode.Space) && bulletsNum >= 1)
        {
            bulletsNum -= 1;//�c��e�������炷
            _bubbleNumDirector.bNum = bulletsNum;
            Instantiate(bubblePrefab2, firepoit.position, transform.rotation);//���𔭎�
            PlayLaunchSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // �G���ǂ����̃^�O���`�F�b�N
        {
            Debug.Log("Enemy");

            Destroy(gameObject);

            //gm.OnPlayerDeath();

            //SceneManager.LoadScene("GameoverScene");

            
        }

        if (collision.gameObject.CompareTag("dirt"))
        {
            Debug.Log("�|�����[�^�[[+1]");
            cleaning += 1;
            _GaugeController2.GaugeNum++;
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


}

