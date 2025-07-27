using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    [SerializeField] private Image hpBarImage;
    [SerializeField] private Sprite[] hpBarSprites; //�X�v���C�g6��
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

        UpdateHPBar();//HP�o�[�̍X�V���s��

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        temp++;
        if (collision.gameObject.CompareTag("bubble")) // �����ǂ����̃^�O���`�F�b�N
        {
            Debug.Log("bubble");
            Destroy(collision.gameObject); // �I�u�W�F�N�g��j��

            if(temp >= 2)
            {
                temp = 0;
                TakeDamage();
            }
            
        }


    }
    // Update is called once per frame

    //HP�o�[�̍X�V
    private void UpdateHPBar()
    {
        if (currentHP >= 5.0f)
        {
            hpBarImage.sprite = hpBarSprites[0]; //�ő�HP
            HitBubbleSound();
        }
        else if (currentHP >= 4.0f)
        {
            hpBarImage.sprite = hpBarSprites[1]; //1�_���[�W���������
            HitBubbleSound();
        }
        else if (currentHP >= 3.0f)
        {
            hpBarImage.sprite = hpBarSprites[2]; //2�_���[�W�H������Ƃ�
            HitBubbleSound();
        }
        else if (currentHP >= 2.0f)
        {
            hpBarImage.sprite = hpBarSprites[3]; //3�_���[�W���炤�ƐԐF�Q�[�W
            HitBubbleSound();
        }
        else if (currentHP >= 1.0f)
        {
            hpBarImage.sprite = hpBarSprites[4]; //4�_���[�W�H������Ƃ�
            HitBubbleSound();
        }
        else
        {
            hpBarImage.sprite = hpBarSprites[5]; //���񂾂Ƃ�
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void HitBubbleSound()
    {
        //AudioSource�Ō��ʉ����Đ�
        if (hitBubble != null)
        {
            hitBubble.Play();
        }
        else
        {
            Debug.Log("AudioSource���ݒ肳��Ă��Ȃ�");
        }
    }

}
