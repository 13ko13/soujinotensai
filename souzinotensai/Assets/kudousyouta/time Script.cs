using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        countdown -= Time.deltaTime;
        //���Ԃ�\������
        timeText.text = countdown.ToString("f1");

        //0�b�ȉ��Ȃ牽�����Ȃ�
       if(countdown <= 0)
        {

        }
            
    }
}
