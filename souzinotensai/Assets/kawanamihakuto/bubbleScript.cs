using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class bubbleScript : MonoBehaviour
{
    public float speed = 0.1f;
   
    // Start is called before the first frame update
    void Start()
    {
      //  Application.targetFrameRate = 60;
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        transform.Translate(0, speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall")) // �ǂ��ǂ����̃^�O���`�F�b�N
        {
            Debug.Log("wall");
             // �I�u�W�F�N�g��j��
            Destroy(gameObject);
        }
    }
}
