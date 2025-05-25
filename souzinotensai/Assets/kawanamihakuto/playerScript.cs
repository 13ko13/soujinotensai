using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform firepoit;
    public float speed = 0.1f;

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
        this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);//������
        //W�L�[�ŏ�ɓ���
        if (Input.GetKeyDown(KeyCode.W))
        {
          transform.eulerAngles=new Vector3(0, 0, 0);
                    this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 50);
            dir = Dir.Up;    
        }
        //S�L�[�ŉ��ɓ���
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, -50);
            dir = Dir.Down;
        }
        //A�L�[�ō��ɓ���
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-50,0);
            dir = Dir.Left;
        }
        //D�L�[�ŉE�ɓ���
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(50, 0);
            Debug.Log("4");
            dir = Dir.Right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
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
