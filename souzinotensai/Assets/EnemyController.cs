using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float time;
    private int vecX;
    private int vecY;
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            //0�ȏ�2�����̒l���o�܂�
            if (Random.Range(0, 2) == 1)
            {
                if(Random.Range(0,2 )== 1)
                {
                    vecX = 1;
                   
                }
                else
                {
                    vecX = -4;
                }
                
            }
            else
            {
                if (Random.Range(0, 2) == 1)
                {
                    vecY = 1;

                }
                else
                {
                    vecY = -4;
                }
            }


            
            transform.position = new Vector3(vecX, vecY, 0);
            time = 1.0f;
        }
    }
}
    


