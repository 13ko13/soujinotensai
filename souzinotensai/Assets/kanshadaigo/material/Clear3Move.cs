using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear3Move : MonoBehaviour
{
    int num = 0;
    int num2 = 0;
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
            num2 += 1;
            if (num2 == 1)
            {
                transform.position = new Vector3(8, -3.0f, 0);
            }
            else if (num2 == 2)
            {
                num = 0;
                num2 = 0;
                transform.position = new Vector3(8, -2.0f, 0);
            }

        }
    }
}
