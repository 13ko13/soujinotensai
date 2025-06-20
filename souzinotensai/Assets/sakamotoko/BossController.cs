using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;
    public int dirt;
    public GameObject Dirt;
    public GameObject Boss;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }
    void TakeDamage()
    {
        currentHP -= 1;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("bubble")) // 球かどうかのタグをチェック
        {
            Debug.Log("bubble");
            Destroy(collision.gameObject); // オブジェクトを破壊
           TakeDamage();
        }
    }
    // Update is called once per frame
   

    void Die()
    {
        Destroy(gameObject);
    }



}
