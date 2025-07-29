using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnScript : MonoBehaviour
{
    public GameObject WarningPrefab1;
    public GameObject WarningPrefab2;
    public GameObject WarningPrefab3;
    public GameObject WarningPrefab4;

    int rnd;
    public GameObject enemyPrefab2_2;
    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;
    public Transform firepoint4;
    private GameObject[] enemybox;
    int temp;
    int SceneNum;
    float time;
    float timer;
    int spawn_pos;

    public AudioSource respawnSound;    //敵リスポーン時の音
    public AudioSource WarningSound;    //警告音
    // Start is called before the first frame update
    void Start()
    {
        WarningPrefab1.SetActive(false);
        WarningPrefab2.SetActive(false);
        WarningPrefab3.SetActive(false);
        WarningPrefab4.SetActive(false);

        temp = 0;
        time = 0;
        timer = 0.1f;
        SceneNum = 0;
        spawn_pos = 0;
        Scene currentScene = SceneManager.GetActiveScene();

        //シーン名を取得
        string sceneName = currentScene.name;

        if (sceneName == "_Stage1")
        {
            SceneNum = 0;
        }
        if (sceneName == "_Stage2")
        {
            SceneNum = 2;
        }
        if (sceneName == "_Stage3")
        {
            SceneNum = 3;
        }
        if (sceneName == "_Stage4")
        {
            SceneNum = 3;
        }
    }

    void SpawnEnemy()
    {
        rnd = Random.Range(1, 5);
        if (rnd == 1)
        {
            WarningPrefab1.SetActive(true);
            if (WarningSound!= null)
            {
                WarningSound.Play();
            }
            Invoke("EnemyRespawn1", 5.0f);  
        }
        if (rnd == 2)
        {
            WarningPrefab2.SetActive(true);
            if (WarningSound!= null)
            {
                WarningSound.Play();
            }

            Invoke("EnemyRespawn2", 5.0f);   
        }
        if (rnd == 3)
        {
            WarningPrefab3.SetActive(true);
            if (WarningSound != null)
            {
                WarningSound.Play();
            }
            Invoke("EnemyRespawn3", 5.0f);
        }
        if (rnd == 4)
        {
            WarningPrefab4.SetActive(true);
            if (WarningSound != null)
            {
                WarningSound.Play();
            }
            Invoke("EnemyRespawn4", 5.0f);
        }    
    }


    // Update is called once per frame
    void Update()
    {
        

        enemybox = GameObject.FindGameObjectsWithTag("Enemy");

        time = Time.deltaTime;
       
        

        if (temp==enemybox.Length&& SceneNum > 0)
        {
            
            Invoke("SpawnEnemy", 10.0f);
            SceneNum--;
            
        }
        temp = enemybox.Length-1;
    }

    void EnemyRespawn1()
    {
        Instantiate(enemyPrefab2_2, firepoint1.position, transform.rotation);
        
        if (respawnSound != null)
        {
            respawnSound.Play();
        }
        WarningPrefab1.SetActive(false);
    }
    void EnemyRespawn2()
    {
        Instantiate(enemyPrefab2_2, firepoint2.position, transform.rotation);

        if (respawnSound != null)
        {
            respawnSound.Play();
        }
        WarningPrefab2.SetActive(false);
    }
    void EnemyRespawn3()
    {
        Instantiate(enemyPrefab2_2, firepoint3.position, transform.rotation);

        if (respawnSound != null)
        {
            respawnSound.Play();
        }
        WarningPrefab3.SetActive(false);
    }
    void EnemyRespawn4()
    {
        Instantiate(enemyPrefab2_2, firepoint4.position, transform.rotation);

        if (respawnSound != null)
        {
            respawnSound.Play();
        }
        WarningPrefab4.SetActive(false);
    }
}
