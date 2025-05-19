using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleshot : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform firepoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bubblePrefab, firepoint.position, transform.rotation);
       
        }
    }
}
