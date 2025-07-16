using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class KudoBossController : MonoBehaviour
{
    [SerializeField] private Image hpBarImage;
    [SerializeField] private Sprite[] hpBarSprites; //スプライト4枚
    [SerializeField] private int maxHP = 5;
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

        UpdateHPBar();//HPバーの更新を行う

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
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

    //HPバーの更新
    private void UpdateHPBar()
    {
        if (currentHP >= 5.0f)
        {
            hpBarImage.sprite = hpBarSprites[0]; //最大HP
        }
        else if (currentHP >= 4.0f)
        {
            hpBarImage.sprite = hpBarSprites[1]; //1ダメージくらった時
        }
        else if (currentHP >= 3.0f)
        {
            hpBarImage.sprite = hpBarSprites[2]; //2ダメージ食らったとき
        }
        else if (currentHP >= 2.0f)
        {
            hpBarImage.sprite = hpBarSprites[3]; //3ダメージくらうと赤色ゲージ
        }
        else if (currentHP >= 1.0f)
        {
            hpBarImage.sprite = hpBarSprites[4]; //4ダメージ食らったとき
        }
        else
        {
            hpBarImage.sprite = hpBarSprites[5]; //死んだとき
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }



}
