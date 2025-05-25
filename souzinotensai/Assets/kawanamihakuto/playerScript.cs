using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform firepoit;
    public float speed = 0.1f;
    private float timeBetweenShot = 3.0f;//球を再度打てるようになるまでの時間
    private float timer;
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
        Application.targetFrameRate = 60;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="wall")
        {
            Debug.Log("aaaaaa");
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);//初期化
        //Wキーで上に動く
        if (Input.GetKeyDown(KeyCode.W))
        {
          transform.eulerAngles=new Vector3(0, 0, 0);
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 50);
            dir = Dir.Up;    
        }
        //Sキーで下に動く
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -50);
            dir = Dir.Down;
        }
        //Aキーで左に動く
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-50,0);
            dir = Dir.Left;
        }
        //Dキーで右に動く
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(50, 0);
            Debug.Log("4");
            dir = Dir.Right;
        }

        timer += Time.deltaTime;//タイマーの時間を動かす

        if (Input.GetKeyDown(KeyCode.Space)&&timer>timeBetweenShot)
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
}
