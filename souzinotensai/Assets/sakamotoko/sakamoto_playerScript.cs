using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sakamoto_player : MonoBehaviour
{
    [SerializeField] private Sprite[] playerSprites; //�X�v���C�g4��
                                                   
    bubbleNumDirector _bubbleNumDirector;
    GaugeController _GaugeController;
    public SpriteRenderer SpriteRenderer;
    public GameObject bubblePrefab;
    public Transform firepoit;
    //public GameObject[] wall;
    public float speed = 0.1f;
    private float timeBetweenShot = 3.0f;//�����ēx�łĂ�悤�ɂȂ�܂ł̎���
    private float timer;
    public int cleaning = 0;//�|��������(reload�̒l�ɒB�����烊�Z�b�g�����)
    public int reload = 10;//�e�𑝂₷�����̒l
    int bulletsNum = 0;//�c��e��(���̏����Œǉ������)


    //public Vector3 wallRightSidePos;
    //public Vector3 wallLeftSidePos;
    //public Vector3 wallUpVerticalPos;
    //public Vector3 wallUnderVerticalPos;
    public Vector3 wallThickY;
    public Vector3 wallThicX;

    public Vector3 cullentPos;

    public GameObject wallRight;
    public GameObject wallLeft;
    public GameObject wallUp;
    public GameObject wallUnder;

    Vector3 wallXScale = new Vector3(2.0f,0.0f,0.0f);
    Vector3 wallYScale = new Vector3(0.0f,2.0f,0.0f);


    void Start()
    {
        _GaugeController = GameObject.Find("Gauge").GetComponent<GaugeController>();


        //UI
        // Slider.maxValue = reload;
        // Slider.value = cleaning;

        //wallRightSidePos = new Vector3(10.5f, 0, 0);
        //wallLeftSidePos = new Vector3(-8.5f, 0, 0);
        //wallUpVerticalPos = new Vector3(0, 7.5f, 0);
        //wallUnderVerticalPos = new Vector3(0, -7.5f, 0);



        //wallLeftSidePos = GameObject.Find("wallLeft").transform.position;
        //Debug.Log(wallLeftSidePos);
        //wallRightSidePos = GameObject.Find("wallRight").transform.position;
        //wallRightSidePos.x -= (transform.position.x / 2);
        //wallUpVerticalPos = GameObject.Find("wallUp").transform.position;
        //wallUpVerticalPos.y -= (transform.position.y / 2);
        //wallUnderVerticalPos = GameObject.Find("wallUnder").transform.position;
        //wallUnderVerticalPos.y += (transform.position.y / 2);

        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
   
    void Update()
    {
        //UI
      //  Slider.value = cleaning;

        

        if(cleaning >= reload)//��萔�����|��������
        {
            Debug.Log("�e��[+1]  �|�����[�^�[���Z�b�g");
            cleaning = 0;//�|���������̃��Z�b�g
            _GaugeController.GaugeNum = 0;
            Debug.Log("�ʂP�����");
            bulletsNum += 1;//�e���P���₷
        }

        //W���������Ƃ�
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            SpriteRenderer.sprite = playerSprites[0];  //�����
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, 1);
            //dir = Dir.Up;
        }
        //S���������Ƃ�
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            SpriteRenderer.sprite = playerSprites[1];  //������
            //SpriteRenderer.transform.eulerAngles = new Vector3(0, 0, 360);
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, -1);
            //dir = Dir.Down;
            
        }
        //A���������Ƃ�
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            SpriteRenderer.sprite = playerSprites[2];  //�E����
            //SpriteRenderer.transform.eulerAngles = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody2D>().position += new Vector2(-1, 0);
            //dir = Dir.Left;
        }
        //D���������Ƃ�
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            SpriteRenderer.sprite = playerSprites[3];  //�E����
            //SpriteRenderer.transform.eulerAngles = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody2D>().position += new Vector2(1, 0);
            // Debug.Log("4");
            //dir = Dir.Right;
        }

        cullentPos = transform.position;

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
            //�ǂ̒��֖߂�
            cullentPos.y = wallUnder.transform.position.y + wallYScale.y;
            cullentPos.z = wallUnder.transform.position.z;
            transform.position = cullentPos;
        }



        timer += Time.deltaTime;//�^�C�}�[�̎��Ԃ𓮂���

        if (Input.GetKeyDown(KeyCode.Space)) //&& bulletsNum >= 1)//timer > timeBetweenShot)
        {
            //timer = 0.0f;//�^�C�}�[�̎��Ԃ�0�ɖ߂�

            bulletsNum -= 1;//�c��e�������炷

            Instantiate(bubblePrefab, firepoit.position, transform.rotation);//���𔭎�

            //if (dir == Dir.Up)
            //{
            //    Instantiate(bubblePrefab, firepoit.position, transform.rotation);
            //    //transform.Translate(0, speed, 0);
            //}
            //if (dir == Dir.Down)
            //{
            //    Instantiate(bubblePrefab, firepoit.position, transform.rotation);
            //    //transform.Translate( 0, -speed, 0);
            //}
            //if (dir == Dir.Left)
            //{
            //    Instantiate(bubblePrefab, firepoit.position, transform.rotation);
            //    //transform.Translate(-speed, 0,  0);
            //}
            //if (dir == Dir.Right)
            //{
            //    Instantiate(bubblePrefab, firepoit.position, transform.rotation);
            //    //transform.Translate(speed, 0,  0);
            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // �G���ǂ����̃^�O���`�F�b�N
        {
            Debug.Log("Enemy");
           
            Destroy(gameObject);

            //SceneManager.LoadScene("GameoverScene");

        }

        if(collision.gameObject.CompareTag("dirt"))
        {
            Debug.Log("�|�����[�^�[[+1]");
            cleaning += 1;
            _GaugeController.GaugeNum++;
            
        }

    }

    
}

