using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private const double V = 0.1;
    float movespeed = (float)V;
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
        if (Input.GetKey(KeyCode.W))
        {
            if (!Input.GetKey(KeyCode.A))
            {
                if (!Input.GetKey(KeyCode.D))
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2);
                }
            }
        }
        //Sキーで下に動く
        if (Input.GetKey(KeyCode.S))
        {
            if (!Input.GetKey(KeyCode.A))
            {
                if (!Input.GetKey(KeyCode.D))
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
                }
            }
        }
        //Aキーで左に動く
        if (Input.GetKey(KeyCode.A))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-2,0);

        }
        //Dキーで右に動く
        if (Input.GetKey(KeyCode.D))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);

        }
        
    }
}
