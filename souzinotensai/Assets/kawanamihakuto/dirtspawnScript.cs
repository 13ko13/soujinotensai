using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtspawnScript : MonoBehaviour
{
    public GameObject dirt_2_Prefab;
   
    public Transform dirtspawnpoint;
   
    float time;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
       
        time= 0;
        timer = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
       
        time = Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.G))
        {
            time = 0;
            Instantiate(dirt_2_Prefab,dirtspawnpoint);
        }
        
    }
}
