using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform firepoit_w;
    int x =0;
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
            x = 1;    
        }
        //Sキーで下に動く
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -50);
            x = 2;
        }
        //Aキーで左に動く
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-50,0);
            x = 3;
        }
        //Dキーで右に動く
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(50, 0);
            x = 4;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (x == 1)
            {
                Instantiate(bubblePrefab, firepoit_w.position, transform.rotation);

            }
        }
    }
}
