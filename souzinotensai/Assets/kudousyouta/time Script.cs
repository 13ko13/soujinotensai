using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeScript : MonoBehaviour
{
    //カウントダウン
    public float countdown = 5.0f;
    //時間を表示するText型の変数
    public Text timeText;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        this.countdown -= Time.deltaTime;
        //時間を表示する
        timeText.text = countdown.ToString("f1");

        //0秒以下ならシーン移動
        if (this.countdown <= 0.0)
        {
            SceneManager.LoadScene("GameoverScene");
        }

    }
}
