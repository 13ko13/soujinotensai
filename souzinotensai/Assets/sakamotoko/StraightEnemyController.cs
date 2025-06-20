using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightEnemyController : MonoBehaviour
{
    Vector3 movedistans;
    Vector3 move;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        time = 0.5f;
        move = transform.position;
        movedistans = new Vector3(1, 0,0);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time >= 0)
        {
            move = transform.position + movedistans;
        }
        



    }
}
