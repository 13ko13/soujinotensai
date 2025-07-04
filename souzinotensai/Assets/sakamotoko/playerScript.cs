using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player2 : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform firepoit;
    public float speed = 0.1f;
    private float timeBetweenShot = 3.0f;//球を再度打てるようになるまでの時間
    private float timer;
    private Vector3 cullentPos;

    enum Dir
    {
        Up,
        Down,
        Left,
        Right,
    }

    Dir dir = Dir.Up;
    // Start is called before the first frame update
    void Start()
    {
        cullentPos = transform.position;
        //Application.targetFrameRate = 60;
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //    if (collision.gameObject.tag == "wall")
    //    {
    //        Debug.Log("aaaaaa");

    //    }
    // }
    // Update is called once per frame
    void Update()
    {



       
        //Wを押したとき
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, 1);
            dir = Dir.Up;
            cullentPos = transform.position;
            Debug.Log(cullentPos);
        }
        //Sを押したとき
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            this.GetComponent<Rigidbody2D>().position += new Vector2(0, -1);
            dir = Dir.Down;
            cullentPos = transform.position;
            Debug.Log(cullentPos);
        }
        //Aを押したとき
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            this.GetComponent<Rigidbody2D>().position += new Vector2(-1, 0);
            dir = Dir.Left;
            cullentPos = transform.position;
            Debug.Log(cullentPos);
        }
        //Dを押したとき
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            this.GetComponent<Rigidbody2D>().position += new Vector2(1, 0);
            // Debug.Log("4");
            dir = Dir.Right;
            cullentPos = transform.position;
            Debug.Log(cullentPos);
        }

        timer += Time.deltaTime;//タイマーの時間を動かす

        if (Input.GetKeyDown(KeyCode.Space) && timer > timeBetweenShot)
        {
            timer = 0.0f;//タイマーの時間を0に戻す

            if (dir == Dir.Up)
            {
                Instantiate(bubblePrefab, firepoit.position, transform.rotation);
                //transform.Translate(0, speed, 0);
            }
            if (dir == Dir.Down)
            {
                Instantiate(bubblePrefab, firepoit.position, transform.rotation);
                //transform.Translate( 0, -speed, 0);
            }
            if (dir == Dir.Left)
            {
                Instantiate(bubblePrefab, firepoit.position, transform.rotation);
                //transform.Translate(-speed, 0,  0);
            }
            if (dir == Dir.Right)
            {
                Instantiate(bubblePrefab, firepoit.position, transform.rotation);
                //transform.Translate(speed, 0,  0);
            }
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

    }
    
}

