using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bubbleScript : MonoBehaviour
{
    public float speed = 0.1f;
   
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);
    }
}
