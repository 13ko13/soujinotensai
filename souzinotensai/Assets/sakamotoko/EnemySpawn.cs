using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        num++;
        if(num % 800 == 0)
        {
            Instantiate(enemy, new Vector3(3, 4, 0),Quaternion.identity);
        }
    }
}
