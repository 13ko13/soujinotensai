using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
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
          
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 50);
              
        }
        //Sキーで下に動く
        if (Input.GetKeyDown(KeyCode.S))
        {
           
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -50);
             
        }
        //Aキーで左に動く
        if (Input.GetKeyDown(KeyCode.A))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-50,0);

        }
        //Dキーで右に動く
        if (Input.GetKeyDown(KeyCode.D))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(50, 0);

        }
        
    }
}
