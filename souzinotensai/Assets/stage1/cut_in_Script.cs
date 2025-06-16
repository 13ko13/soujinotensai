using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cut_in_Script : MonoBehaviour
{
    float timer;
    const float timecount = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        if (timer > timecount)
        {
            SceneManager.LoadScene("stage1");
        }
    }
}
