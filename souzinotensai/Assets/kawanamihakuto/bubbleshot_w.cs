using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleshot : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform firepoint_w;
    int k;
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
     //   if (Input.anyKey)
        {
        //    k = 5;
        }
        if (k == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bubblePrefab, firepoint_w.position, transform.rotation);

            }
        }
    }
}
