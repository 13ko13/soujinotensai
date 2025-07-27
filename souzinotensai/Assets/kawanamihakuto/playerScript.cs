using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class player : MonoBehaviour
{
    [SerializeField] private Sprite[] playerSprites; //スプライト4枚

    bubbleNumDirector _bubbleNumDirector;
    GaugeController _GaugeController;
    GameManager gm;
    public SpriteRenderer SpriteRenderer;
    public GameObject bubblePrefab;
    public Transform firepoit;
    public GameObject[] wall;
    public float speed = 0.1f;
    private float timer;
    public int cleaning = 0;//掃除した数(reloadの値に達したらリセットされる)
    public int reload = 20;//弾を増やす条件の値
    int bulletsNum = 0;//残り弾数(↑の条件で追加される)
    int frame=0;

    public GameObject wallRight;
    public GameObject wallLeft;
    public GameObject wallUp;
    public GameObject wallUnder;

    public Vector3 wallXScale;
    public Vector3 wallYScale;
    public Vector3 cullentPos;

    public AudioSource launchSoundSource;//効果音AudioSource
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

        if (cleaning >= reload)//一定数汚れを掃除したら
        {
            Debug.Log("弾数[+1]  掃除メーターリセット");
            cleaning = 0;//掃除した数のリセット
            _GaugeController.GaugeNum = 0;
            Debug.Log("玉１だよん");
            bulletsNum += 1;//弾を１つ増やす
            _bubbleNumDirector.bNum = bulletsNum;
            ChargeBubbleSound();
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
            SpriteRenderer.sprite = playerSprites[2];  //右向き
            this.GetComponent<Rigidbody2D>().position += new Vector2(-1, 0);
        }
        //Dを押したとき
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            SpriteRenderer.sprite = playerSprites[3];  //右向き
            this.GetComponent<Rigidbody2D>().position += new Vector2(1, 0);
        }

        cullentPos = transform.position; //現在の位置を記憶

        if (transform.position.x > wallRight.transform.position.x - wallXScale.x) //右の壁にめりこんだら
        {
            //壁の中へ戻す
            cullentPos.x = wallRight.transform.position.x - wallXScale.x;
            cullentPos.z = wallRight.transform.position.z;
            transform.position = cullentPos;
        }
        if (transform.position.x < wallLeft.transform.position.x + wallXScale.x) //左の壁にめりこんだら
        {
            //壁の中へ戻す
            cullentPos.x = wallLeft.transform.position.x + wallXScale.x;
            cullentPos.z = wallLeft.transform.position.z;
            transform.position = cullentPos;
        }
        if (transform.position.y > wallUp.transform.position.y - wallYScale.y) //上の壁にめりこんだら
        {
            //壁の中へ戻す
            cullentPos.y = wallUp.transform.position.y - wallYScale.y;
            cullentPos.z = wallUp.transform.position.z;
            transform.position = cullentPos;
        }
        if (transform.position.y < wallUnder.transform.position.y + wallYScale.y) //下の壁にめりこんだら
        {
            Debug.Log("壁");
            //壁の中へ戻す
            cullentPos.y = wallUnder.transform.position.y + wallYScale.y;
            cullentPos.z = wallUnder.transform.position.z;
            transform.position = cullentPos;
        }



        timer += Time.deltaTime;//タイマーの時間を動かす

        if (Input.GetKeyDown(KeyCode.Space) && bulletsNum >= 1)
        {
            bulletsNum -= 1;//残り弾数を減らす
            _bubbleNumDirector.bNum = bulletsNum;
            Instantiate(bubblePrefab, firepoit.position, transform.rotation);//球を発射
            PlayLaunchSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // 敵かどうかのタグをチェック
        {
            Debug.Log("Enemy");

            Destroy(gameObject);
            isDie = true;

            //SceneManager.LoadScene("GameoverScene");

            
        }

        if (collision.gameObject.CompareTag("dirt"))
        {
            Debug.Log("掃除メーター[+1]");
            cleaning += 1;
            _GaugeController.GaugeNum++;
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

    void ChargeBubbleSound()
    {
        if (chargeBubble != null)
        {
            chargeBubble.Play();
        }
    }
}

