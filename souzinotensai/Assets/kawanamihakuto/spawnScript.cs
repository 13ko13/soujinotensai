using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{

    public GameObject enemyPrefab;

    private GameObject[] enemybox;
    int temp;
    int num;
    float time;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        temp = 0;
        time = 0;
        timer = 0.1f;
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemybox = GameObject.FindGameObjectsWithTag("Enemy");

        time = Time.deltaTime;
       
        if (temp==enemybox.Length&&num!=5)
        {
          num++;
            Instantiate(enemyPrefab);
        }
        temp = enemybox.Length-1;
    }
}
