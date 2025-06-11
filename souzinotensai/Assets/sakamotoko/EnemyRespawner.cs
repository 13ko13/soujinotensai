using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{

    public int Respawner = 2;
    private GameObject Boss;
    private GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Boss = GetComponent<GameObject>();
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy != true)
        {
            Instantiate(Enemy,new Vector2(0,0), Quaternion.identity);
        }
    }
}

