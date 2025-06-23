using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kudoitem : MonoBehaviour
{
    
    //プレイヤーを特定
    Transform playerTr;
    //敵のスピード調整
    [SerializeField] float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーとの距離が0.1未満になったらそれ以上実行しない

        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
        {

        }


        //プレイヤーの方向にいく
        transform.position = Vector2.MoveTowards
            (transform.position, new Vector2(playerTr.position.x, playerTr.position.y), speed * Time.deltaTime);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))//プレイヤーかどうかのタグをチェック
        {
            
            
            Destroy(gameObject);
            

        }
    }
}

