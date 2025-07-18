using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnScript : MonoBehaviour
{
    int rnd;
    public GameObject enemyPrefab;
    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;
    public Transform firepoint4;
    private GameObject[] enemybox;
    int temp;
    int num;
    float time;
    float timer;
    int spawn_pos;
    // Start is called before the first frame update
    void Start()
    {
        temp = 0;
        time = 0;
        timer = 0.1f;
        num = 0;
        spawn_pos = 0;
    }

    void SpawnEnemy()
    {
        rnd = Random.Range(1, 5);
        if (rnd == 1)
            Instantiate(enemyPrefab,firepoint1.position,transform.rotation);
        if (rnd == 2)
            Instantiate(enemyPrefab, firepoint2.position, transform.rotation);
        if (rnd == 3)
            Instantiate(enemyPrefab, firepoint3.position, transform.rotation);
        if (rnd == 4)
            Instantiate(enemyPrefab, firepoint4.position, transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        enemybox = GameObject.FindGameObjectsWithTag("Enemy");

        time = Time.deltaTime;
       
        if (temp==enemybox.Length&&num!=2)
        {
            
            Invoke("SpawnEnemy", 10.0f);
            num++;
            
        }
        temp = enemybox.Length-1;
    }
}
