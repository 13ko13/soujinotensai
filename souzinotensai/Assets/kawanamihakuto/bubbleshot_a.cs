using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleshot_a : MonoBehaviour
{
    int k;
    public GameObject bubblePrefab;
    public Transform firepoint_a;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            k = 1;

        }
      //  if(Input.)
        {
     //       k = 5;
        }
        if (k == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bubblePrefab, firepoint_a.position, transform.rotation);

            }
        }
    }
}
