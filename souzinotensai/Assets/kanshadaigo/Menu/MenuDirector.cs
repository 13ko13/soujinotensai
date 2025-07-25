using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDirector : MonoBehaviour
{
    public AudioSource launchSoundSource;//���ʉ�AudioSource
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            PlayLaunchSound();
            while(true)
            {
                if (!launchSoundSource.isPlaying)
                {
                    SceneManager.LoadScene("_Stage1");
                }
            }
            
            
        }
    }
    void PlayLaunchSound()
    {
        //AudioSource�Ō��ʉ����Đ�
        if (launchSoundSource != null)
        {
            launchSoundSource.Play();
        }
        else
        {
            Debug.Log("AudioSource���ݒ肳��Ă��Ȃ�");
        }


    }


}
