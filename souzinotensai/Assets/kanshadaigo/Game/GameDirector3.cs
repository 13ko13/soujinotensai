using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameDirector3 : MonoBehaviour
{
    private GameObject[] dirtBox;
    private GameObject[] playerBox;
    GameObject hpGauge;

    private int stageNum;        //ステージ数
    private int currentStageNum; //現在のステージ数

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
        stageNum = 1;
    }

    private void Update()
    {
        dirtBox = GameObject.FindGameObjectsWithTag("dirt");
        playerBox = GameObject.FindGameObjectsWithTag("player");

        if (dirtBox.Length == 0)
        {
            Debug.Log("ステージクリア");
            SceneManager.LoadScene("StageClearScene3");
            CountStage();

        }
        if (playerBox.Length == 0)
        {
            SceneManager.LoadScene("GameoverScene");
        }


        //ステージ1がクリアされるとステージ2に進む
        if (stageNum == 2)
        {
            SceneManager.LoadScene("StageClearScene");
        }
        //ステージ2がクリアされるとステージ3に進む
        if (stageNum == 3)
        {
            SceneManager.LoadScene("StageClearScene2");
        }
        //ステージ1がクリアされるとステージ4に進む
        if (stageNum == 4)
        {
            SceneManager.LoadScene("StageClearScene3");
        }
    }
    // Update is called once per frame
    public void DecreaseHP()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public int CountStage()
    {
        if (currentStageNum == 1)
        {
            stageNum = 2;
            currentStageNum = 2;
        }
        if (currentStageNum == 2)
        {
            stageNum = 3;
            currentStageNum = 3;
        }
        if (currentStageNum == 3)
        {
            stageNum = 4;
        }


        return stageNum;
    }

}