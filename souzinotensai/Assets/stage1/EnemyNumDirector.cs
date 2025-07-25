using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyNumDirector : MonoBehaviour
{

    public GameObject EnemyNum;
    int eNum = 0;
    int temp;
    private GameObject[] enemybox;

    public AudioSource enemySound;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        //ƒV[ƒ“–¼‚ğæ“¾
        string sceneName = currentScene.name;

        if (sceneName == "_Stage1")
        {
            eNum = 3;
        }
        if (sceneName == "_Stage2")
        {
            eNum = 6;
        }
        if (sceneName == "_Stage3")
        {
            eNum = 7;
        }
        if (sceneName == "_Stage4")
        {
            eNum = 7;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Text _EnemyNum = EnemyNum.GetComponent<Text>();

        _EnemyNum.text = "Enemy~" + eNum;

        enemybox = GameObject.FindGameObjectsWithTag("Enemy");

        if (temp == enemybox.Length)
        {
            eNum--;
            EnemySound();
        }
        temp = enemybox.Length - 1;



    }

    void EnemySound()
    {
        //AudioSource‚ÅŒø‰Ê‰¹‚ğÄ¶
        if (enemySound != null)
        {
            enemySound.Play();
        }
        else
        {
            Debug.Log("AudioSource‚ªİ’è‚³‚ê‚Ä‚¢‚È‚¢");
        }
    }
}
