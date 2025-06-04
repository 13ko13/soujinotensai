using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
         private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player")) // playerかどうかのタグをチェック
        {
            Debug.Log("player");
           
            Destroy(gameObject);//汚れを消す
        }
        if(collision.gameObject.CompareTag("sikaku"))
        {
            Destroy(gameObject);//汚れを消す
        }
    }
}

