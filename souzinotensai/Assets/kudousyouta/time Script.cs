using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class timeScript : MonoBehaviour
{
    GameObject g;
    Text timeText;
    public float timer = 30;

    public void Start()
    {
       
        timeText = GameObject.Find("ScoreText").GetComponent<Text>();
       
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = timer.ToString("F1");
        //0�b�ȉ��Ȃ�V�[���ړ�
        if (this.timer <= 0.0)
        {
            SceneManager.LoadScene("Timeoverscene");
        }

    }
}
