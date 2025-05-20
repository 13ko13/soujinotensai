using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleScript : MonoBehaviour
{
    int k;
    int shot;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.W))
        {
          k = 0;
        
        }

        if (k == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shot = 0;
                if (shot == 0)
                {
                    transform.Translate(0, 0.1f, 0);

                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            k = 1;

        }

        if (k == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shot = 0;
                if (shot == 0)
                {
                    transform.Translate(-0.1f, 0, 0);

                }
            }
           
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            k = 2;

        }

        if (k == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shot = 0;
                if (shot == 0)
                {
                    transform.Translate(0, -0.1f, 0);

                }
            }
           
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            k = 3;

        }

        if (k == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shot = 0;
                if (shot == 0)
                {
                    transform.Translate(0.1f, 0, 0);

                }
            }
          
        }
    }
}
