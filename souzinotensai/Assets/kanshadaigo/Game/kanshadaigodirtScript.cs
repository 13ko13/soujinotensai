using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanshadaigodirtScript : MonoBehaviour
{
    GameObject player;
    public float timer;
    public float timeBetweenShot = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player")) // playerかどうかのタグをチェック
        {
            //Debug.Log("player");

            Destroy(gameObject);//汚れを消す
        }
        if (collision.gameObject.CompareTag("sikaku"))
        {
            Destroy(gameObject);//汚れを消す
        }

        if (collision.gameObject.CompareTag("dirt"))//汚れかどうかのタグをチェック
        {
            if (timer > timeBetweenShot)
            {
                Destroy(gameObject);
            }

        }
    }
}

