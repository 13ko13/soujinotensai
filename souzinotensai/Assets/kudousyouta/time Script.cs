using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeScript : MonoBehaviour
{
    //�J�E���g�_�E��
    public float countdown = 5.0f;
    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        this.countdown -= Time.deltaTime;
        //���Ԃ�\������
        timeText.text = countdown.ToString("f1");

        //0�b�ȉ��Ȃ�V�[���ړ�
        if (this.countdown <= 0.0)
        {
            SceneManager.LoadScene("GameoverScene");
        }

    }
}
