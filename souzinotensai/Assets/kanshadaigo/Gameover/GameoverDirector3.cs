using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverDirector3 : MonoBehaviour
{
    public string menuSceneName = "Gameoverscene3";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("_Stage3");
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
