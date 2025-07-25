using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
public class player4 : MonoBehaviour
{
    [SerializeField] private Sprite[] playerSprites; //スプライト4枚

    bubbleNumDirector _bubbleNumDirector;
    GaugeController2 _GaugeController2;
    GameManager gm;
    public SpriteRenderer SpriteRenderer;
    public GameObject bubblePrefab2;
    public Transform firepoit;
    public GameObject[] wall;
    public float speed = 0.1f;
    private float timeBetweenShot = 3.0f;//球を再度打てるようになるまでの時間
    private float timer;
    public int cleaning = 0;//掃除した数(reloadの値に達したらリセットされる)
    public int reload = 30;//弾を増やす条件の値
    int bulletsNum = 0;//残り弾数(↑の条件で追加される)
    int frame=0;

    public Vector3 wallRightSidePos;
    public Vector3 wallLeftSidePos;
    public Vector3 wallUpVerticalPos;
    public Vector3 wallUnderVerticalPos;
    public Vector3 wallThickY;
    public Vector3 wallThicX;

    public Vector3 cullentPos;

    public AudioSource launchSoundSource;//効果音AudioSource
    public AudioSource dirtSound;
    void Start()
    {
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>(); //ゲームマネージャー

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
        if (cleaning >= reload)//一定数汚れを掃除したら
        {
            Debug.Log("弾数[+1]  掃除メーターリセット");
            cleaning = 0;//掃除した数のリセット
            _GaugeController2.GaugeNum = 0;
            Debug.Log("玉１だよん");
            bulletsNum += 1;//弾を１つ増やす
            _bubbleNumDirector.bNum = bulletsNum;
        }

        //Wを押したとき
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            SpriteRenderer.sprite = playerSprites[0];  //上向き
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, 1);
        }
        //Sを押したとき
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            SpriteRenderer.sprite = playerSprites[1];  //下向き
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, -1);
        }
        //Aを押したとき
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            SpriteRenderer.sprite = playerSprites[2];  //左向き
            this.GetComponent<Rigidbody2D>().position += new Vector2(-1, 0);
        }
        //Dを押したとき
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            SpriteRenderer.sprite = playerSprites[3];  //右向き
            this.GetComponent<Rigidbody2D>().position += new Vector2(1, 0);
        }

        if (transform.position.x > wallRightSidePos.x) //右の壁にめりこんだら
        {
            //壁の中へ戻す
            cullentPos.x = wallRightSidePos.x;
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

        if (Input.GetKeyDown(KeyCode.Space) && bulletsNum >= 1)
        {
            bulletsNum -= 1;//残り弾数を減らす
            _bubbleNumDirector.bNum = bulletsNum;
            Instantiate(bubblePrefab2, firepoit.position, transform.rotation);//球を発射
            PlayLaunchSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // 敵かどうかのタグをチェック
        {
            Debug.Log("Enemy");

            Destroy(gameObject);

            //gm.OnPlayerDeath();

            //SceneManager.LoadScene("GameoverScene");

            
        }

        if (collision.gameObject.CompareTag("dirt"))
        {
            Debug.Log("掃除メーター[+1]");
            cleaning += 1;
            _GaugeController2.GaugeNum++;
            PlayDirtSound();
        }

    }
    void PlayLaunchSound()
    {
        //AudioSourceで効果音を再生
        if (launchSoundSource != null)
        {
            launchSoundSource.Play();
        }
        else
        {
            Debug.Log("AudioSourceが設定されていない");
        }
    }

    void PlayDirtSound()
    {
        //AudioSourceで効果音を再生
        if (dirtSound != null)
        {
            dirtSound.Play();
        }
        else
        {
            Debug.Log("AudioSourceが設定されていない");
        }
    }


}

