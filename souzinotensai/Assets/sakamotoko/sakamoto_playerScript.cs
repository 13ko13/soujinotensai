using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
public class sakamoto_player : MonoBehaviour
{
    //UI
   // public Slider Slider;
   bubbleNumDirector _bubbleNumDirector;
    GaugeController _GaugeController;

    public GameObject bubblePrefab;
    public Transform firepoit;
    public GameObject[] wall;
    public float speed = 0.1f;
    private float timeBetweenShot = 3.0f;//球を再度打てるようになるまでの時間
    private float timer;
    public int cleaning = 0;//掃除した数(reloadの値に達したらリセットされる)
    public int reload = 10;//弾を増やす条件の値
    int bulletsNum = 0;//残り弾数(↑の条件で追加される)


    public Vector3 wallRightSidePos;
    public Vector3 wallLeftSidePos;
    public Vector3 wallUpVerticalPos;
    public Vector3 wallUnderVerticalPos;
    public Vector3 wallThickY;
    public Vector3 wallThicX;

    public Vector3 cullentPos;


    //enum Dir
    //{
    //    Up,
    //    Down,
    //    Left,
    //    Right,
    //}

    //Dir dir = Dir.Up;
    // Start is called before the first frame update
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

        

        wallLeftSidePos = GameObject.Find("wallLeft").transform.position;
        Debug.Log(wallLeftSidePos);
        wallRightSidePos = GameObject.Find("wallRight").transform.position;
        wallRightSidePos.x -= (transform.position.x / 2);
        wallUpVerticalPos = GameObject.Find("wallUp").transform.position;
        wallUpVerticalPos.y -= (transform.position.y / 2);
        wallUnderVerticalPos = GameObject.Find("wallUnder").transform.position;
        wallUnderVerticalPos.y += (transform.position.y / 2);
    }
   
    void Update()
    {
        //UI
      //  Slider.value = cleaning;

        cullentPos = transform.position;
        if(cleaning >= reload)//一定数汚れを掃除したら
        {
            Debug.Log("弾数[+1]  掃除メーターリセット");
            cleaning = 0;//掃除した数のリセット
            _GaugeController.a = 0;
            Debug.Log("玉１だよん");
            bulletsNum += 1;//弾を１つ増やす
        }

        //Wを押したとき
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, 1);
            //dir = Dir.Up;
        }
        //Sを押したとき
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, -1);
            //dir = Dir.Down;
        }
        //Aを押したとき
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            this.GetComponent<Rigidbody2D>().position += new Vector2(-1, 0);
            //dir = Dir.Left;
        }
        //Dを押したとき
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            this.GetComponent<Rigidbody2D>().position += new Vector2(1, 0);
            // Debug.Log("4");
            //dir = Dir.Right;
        }

        if(transform.position.x > wallRightSidePos.x) //右の壁にめりこんだら
        {
            //壁の中へ戻す
            cullentPos.x = wallRightSidePos.x;
            Debug.Log(cullentPos.x);
            transform.position = cullentPos;
        }
        if (transform.position.x < wallLeftSidePos.x) //左の壁にめりこんだら
        {
            //壁の中へ戻す
            cullentPos.x = wallLeftSidePos.x;
            Debug.Log(cullentPos.x);
            transform.position = cullentPos;
        }
        if (transform.position.y > wallUpVerticalPos.y) //上の壁にめりこんだら
        {
            //壁の中へ戻す
            cullentPos.y = wallUpVerticalPos.y;
            transform.position = cullentPos;
        }
        if (transform.position.y < wallUnderVerticalPos.y) //下の壁にめりこんだら
        {
            //壁の中へ戻す
            cullentPos.y = wallUnderVerticalPos.y;
            transform.position = cullentPos;
        }



        timer += Time.deltaTime;//タイマーの時間を動かす

        if (Input.GetKeyDown(KeyCode.Space)) //&& bulletsNum >= 1)//timer > timeBetweenShot)
        {
            //timer = 0.0f;//タイマーの時間を0に戻す

            bulletsNum -= 1;//残り弾数を減らす

            Instantiate(bubblePrefab, firepoit.position, transform.rotation);//球を発射

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
        if (collision.gameObject.CompareTag("Enemy")) // 敵かどうかのタグをチェック
        {
            Debug.Log("Enemy");
           
            Destroy(gameObject);

            //SceneManager.LoadScene("GameoverScene");

        }

        if(collision.gameObject.CompareTag("dirt"))
        {
            Debug.Log("掃除メーター[+1]");
            cleaning += 1;
            _GaugeController.a++;
            
        }

    }

    
}

