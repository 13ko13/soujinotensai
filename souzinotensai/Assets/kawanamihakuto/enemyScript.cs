using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
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
        if (collision.gameObject.CompareTag("bubble")) // 球かどうかのタグをチェック
        {
            Debug.Log("enemyを倒した");
            Destroy(collision.gameObject); // オブジェクトを破壊
            Destroy(gameObject); 
        }
    }
}
