using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightEnemyController : MonoBehaviour
{
    [SerializeField] float time = 1f;
    Vector3 movedistans;
    Vector3 move;
    


    // Start is called before the first frame update
    void Start()
    {
        
        move = transform.position;
        movedistans = new Vector3(0.5f, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= 0.5f;
        Debug.Log(time);
        if(time <=  0)
        {
            //左右に移動し続ける
            transform.position = transform.position + movedistans; //右に移動する
            if(gameObject)
            Debug.Log("移動した");
            
        }
        //move = transform.position;
        
    }
}
