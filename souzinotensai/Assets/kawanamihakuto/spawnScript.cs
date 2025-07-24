using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnScript : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        temp = 0;
        time = 0;
        timer = 0.1f;
        SceneNum = 0;
        spawn_pos = 0;
        Scene currentScene = SceneManager.GetActiveScene();

        //ƒV[ƒ“–¼‚ðŽæ“¾
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
            Instantiate(enemyPrefab2_2,firepoint1.position,transform.rotation);
        if (rnd == 2)
            Instantiate(enemyPrefab2_2, firepoint2.position, transform.rotation);
        if (rnd == 3)
            Instantiate(enemyPrefab2_2, firepoint3.position, transform.rotation);
        if (rnd == 4)
            Instantiate(enemyPrefab2_2, firepoint4.position, transform.rotation);
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
}
