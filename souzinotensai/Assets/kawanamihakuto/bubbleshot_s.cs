using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleshot_s : MonoBehaviour
{
    int k;
    public GameObject bubblePrefab;
    public Transform firepoint_s;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            k = 2;

        }
     //   if (Input.anyKey)
        {
         //   k = 5;
        }
        if (k == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bubblePrefab, firepoint_s.position, transform.rotation);

            }
        }
       
    }
}
