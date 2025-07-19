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
        //0�b�ȉ��Ȃ�V�[���ړ�
        if (this.timer <= 0.0)
        {
            SceneManager.LoadScene("Timeoverscene");
        }
    void timeUp()
    {
        lives--;

       if (lives > 0)
        {
            //���݂̃X�e�[�W�Ŏ���ł������邤���͂��̃X�e�[�W�ŕ�������
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // �c�@0 �� ���j���[�V�[����
            SceneManager.LoadScene("MenuScene"); // ���V�[�����͎����̂ɍ��킹��
        }
    }

    }
}
