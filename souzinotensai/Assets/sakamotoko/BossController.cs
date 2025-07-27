using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    [SerializeField] private Image hpBarImage;
    [SerializeField] private Sprite[] hpBarSprites; //スプライト6枚
    [SerializeField] private int maxHP = 5;
    public int currentHP;
    public int dirt;
    public GameObject Dirt;
    public GameObject Boss;
    int temp = 0;

    public AudioSource hitBubble;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        temp++;
        if (collision.gameObject.CompareTag("bubble")) // 球かどうかのタグをチェック
        {
            Debug.Log("bubble");
            Destroy(collision.gameObject); // オブジェクトを破壊

            if(temp >= 2)
            {
                temp = 0;
                TakeDamage();
            }
            
        }


    }
    // Update is called once per frame

    //HPバーの更新
    private void UpdateHPBar()
    {
        if (currentHP >= 5.0f)
        {
            hpBarImage.sprite = hpBarSprites[0]; //最大HP
            HitBubbleSound();
        }
        else if (currentHP >= 4.0f)
        {
            hpBarImage.sprite = hpBarSprites[1]; //1ダメージくらった時
            HitBubbleSound();
        }
        else if (currentHP >= 3.0f)
        {
            hpBarImage.sprite = hpBarSprites[2]; //2ダメージ食らったとき
            HitBubbleSound();
        }
        else if (currentHP >= 2.0f)
        {
            hpBarImage.sprite = hpBarSprites[3]; //3ダメージくらうと赤色ゲージ
            HitBubbleSound();
        }
        else if (currentHP >= 1.0f)
        {
            hpBarImage.sprite = hpBarSprites[4]; //4ダメージ食らったとき
            HitBubbleSound();
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

    void HitBubbleSound()
    {
        //AudioSourceで効果音を再生
        if (hitBubble != null)
        {
            hitBubble.Play();
        }
        else
        {
            Debug.Log("AudioSourceが設定されていない");
        }
    }

}
