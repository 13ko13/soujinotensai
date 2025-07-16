using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyNumDirector : MonoBehaviour
{

    public GameObject EnemyNum;
    public int eNum;
    private GameObject[] enemybox;
    // Start is called before the first frame update
    void Start()
    {
        eNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Text _EnemyNum = EnemyNum.GetComponent<Text>();

        _EnemyNum.text = "Enemy:" + eNum;

        enemybox = GameObject.FindGameObjectsWithTag("Enemy");

        eNum = enemybox.Length;



    }
}
