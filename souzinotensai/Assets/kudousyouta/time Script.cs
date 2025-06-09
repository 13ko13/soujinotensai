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
    float timer = 30;

    private void Start()
    {
       
        timeText = GameObject.Find("ScoreText").GetComponent<Text>();
       
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = timer.ToString("F1");
        //0ïbà»â∫Ç»ÇÁÉVÅ[Éìà⁄ìÆ
        if (this.timer <= 0.0)
        {
            SceneManager.LoadScene("GameoverScene");
        }

    }
}
