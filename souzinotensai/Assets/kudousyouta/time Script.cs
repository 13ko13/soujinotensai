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
    public int lives = 3;
    public string gameoverscene =  "Gameoverscene";

    public void Start()
    {
       
        timeText = GameObject.Find("ScoreText").GetComponent<Text>();
       
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = timer.ToString("F1");
        //0秒以下ならシーン移動
        if (this.timer <= 0.0)
        {
            SceneManager.LoadScene("Timeoverscene");
        }
    void timeUp()
    {
        lives--;

       if (lives > 0)
        {
            //現在のステージで死んでもがあるうちはそのステージで復活する
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // 残機0 → メニューシーンへ
            SceneManager.LoadScene("MenuScene"); // ←シーン名は自分のに合わせて
        }
    }

    }
}
