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
        if (collision.gameObject.CompareTag("player")) // player���ǂ����̃^�O���`�F�b�N
        {
            Debug.Log("player");
           
            Destroy(gameObject);//���������
        }
        if(collision.gameObject.CompareTag("sikaku"))
        {
            Destroy(gameObject);//���������
        }
    }
}

