using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuMove : MonoBehaviour
{
    Vector3 arrow = new Vector3 (0f, 0f, 1.0f);
    Quaternion q;
    int num;
    int num2;
    int num3;
    float temp;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        num2 = 0;
        num3 = 0;
        time = 0.0f;
        temp = 0.0f;
        q = Quaternion.AngleAxis(1.0f, arrow);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (num3 <= 0)
            {
                num++;
                if (num >= 30)
                {
                    num = 0;
                    num2 += 1;
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
            if (num3 >= 1)
            {
                this.transform.rotation = q * this.transform.rotation;
            }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            num3 += 10;
        }
    }

}
