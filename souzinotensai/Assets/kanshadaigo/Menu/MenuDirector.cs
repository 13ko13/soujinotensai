using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDirector : MonoBehaviour
{
    int num;
    int num2;
    public AudioSource launchSoundSource;//���ʉ�AudioSource
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        num2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (num2 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                num2++;
                PlayLaunchSound();
            }
        }
        
        if(num>=1)
        {
            if (!launchSoundSource.isPlaying)
            {
                SceneManager.LoadScene("_Stage1");
            }
        }
        
    }
    void PlayLaunchSound()
    {
        //AudioSource�Ō��ʉ����Đ�
        if (launchSoundSource != null)
        {
            launchSoundSource.Play();
            num++;
        }
        else
        {
            Debug.Log("AudioSource���ݒ肳��Ă��Ȃ�");
        }


    }


}
