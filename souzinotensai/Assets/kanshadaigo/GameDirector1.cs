using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector1 : MonoBehaviour
{

    private GameObject[] dirtBox;
    private GameObject[] playerBox;
    GameObject hpGauge;
    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    private void Update()
    {
        dirtBox = GameObject.FindGameObjectsWithTag("dirt");
        playerBox = GameObject.FindGameObjectsWithTag("player");

        if (dirtBox.Length == 0)
        {
            SceneManager.LoadScene("GameclearScene");
        }
        if (playerBox.Length == 0)
        {
            SceneManager.LoadScene("GameoverScene");
        }
    }
    // Update is called once per frame
    public void DecreaseHP()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}