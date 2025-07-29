using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    public string menuSceneName = "MenuScene";
    public AudioSource SE;
    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (num < 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlaySE();
                num++;
            }
        }

        if (num >= 1)
        {
            if (!SE.isPlaying)
            {
                SceneManager.LoadScene("_stage1");
            }
        }
        


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
    void PlaySE()
    {
        //AudioSource‚ÅŒø‰Ê‰¹‚ğÄ¶
        if (SE != null)
        {
            SE.Play();

        }
        else
        {
            Debug.Log("AudioSource‚ªİ’è‚³‚ê‚Ä‚¢‚È‚¢");
        }


    }
}
