using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeoverDirector : MonoBehaviour
{
    public string menuSceneName = "Timeoverscene";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("_Stage1");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
