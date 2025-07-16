using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class KudoBossController : MonoBehaviour
{
    [SerializeField] private Image hpBarImage;
    [SerializeField] private Sprite[] hpBarSprites; //�X�v���C�g4��
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

        UpdateHPBar();//HP�o�[�̍X�V���s��

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

        if (collision.gameObject.CompareTag("bubble")) // �����ǂ����̃^�O���`�F�b�N
        {
            Debug.Log("bubble");
            Destroy(collision.gameObject); // �I�u�W�F�N�g��j��
            TakeDamage();
        }


    }
    // Update is called once per frame

    //HP�o�[�̍X�V
    private void UpdateHPBar()
    {
        if (currentHP >= 5.0f)
        {
            hpBarImage.sprite = hpBarSprites[0]; //�ő�HP
        }
        else if (currentHP >= 4.0f)
        {
            hpBarImage.sprite = hpBarSprites[1]; //1�_���[�W���������
        }
        else if (currentHP >= 3.0f)
        {
            hpBarImage.sprite = hpBarSprites[2]; //2�_���[�W�H������Ƃ�
        }
        else if (currentHP >= 2.0f)
        {
            hpBarImage.sprite = hpBarSprites[3]; //3�_���[�W���炤�ƐԐF�Q�[�W
        }
        else if (currentHP >= 1.0f)
        {
            hpBarImage.sprite = hpBarSprites[4]; //4�_���[�W�H������Ƃ�
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



}
