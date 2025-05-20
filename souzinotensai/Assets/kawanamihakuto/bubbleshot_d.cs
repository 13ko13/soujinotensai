using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleshot_d : MonoBehaviour
{
    int k;
    public GameObject bubblePrefab;
    public Transform firepoint_d;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            k = 3;

        }
  //      if (Input.anyKey)
        {
        //    k = 5;
        }
        if (k == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bubblePrefab, firepoint_d.position, transform.rotation);

            }
        }
    }
}
