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
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);//������
        //W�L�[�ŏ�ɓ���
        if (Input.GetKeyDown(KeyCode.W))
        {
          
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 50);
              
        }
        //S�L�[�ŉ��ɓ���
        if (Input.GetKeyDown(KeyCode.S))
        {
           
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -50);
             
        }
        //A�L�[�ō��ɓ���
        if (Input.GetKeyDown(KeyCode.A))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-50,0);

        }
        //D�L�[�ŉE�ɓ���
        if (Input.GetKeyDown(KeyCode.D))
        {

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(50, 0);

        }
        
    }
}
