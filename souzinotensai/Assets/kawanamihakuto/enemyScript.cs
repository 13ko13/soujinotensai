using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bubble")) // �����ǂ����̃^�O���`�F�b�N
        {
            Debug.Log("bubble");
            Destroy(collision.gameObject); // �I�u�W�F�N�g��j��
            Destroy(gameObject); 
        }
    }
}
