using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMove : MonoBehaviour
{
   
    int num;
    int num2;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        num2 = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        num++;
        if (num >= 30)
        {
            num = 0;
            num2 +=1;
            if (num2 == 1)
            {
                transform.position = new Vector3(-1.0f, 0, 0);
            }
            else if (num2 == 2)
            {
                num = 0;
                num2 = 0;
                transform.position = new Vector3(1.0f, 0, 0);
            }
            
        }    
       
    }
    
}
