using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtScript : MonoBehaviour
{
    
    public float timer;
    public float timeBetweenShot = 0.1f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

    }

    
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player")) // player���ǂ����̃^�O���`�F�b�N
        {
            //Debug.Log("player");
           
            Destroy(gameObject);//���������
        }
        if(collision.gameObject.CompareTag("sikaku"))
        {
            Destroy(gameObject);//���������
        }

      //if(collision.gameObject.CompareTag("dirt")) //���ꂩ�ǂ����̃^�O���`�F�b�N
      //{
      //OldDirtDelete.SpawnDirt(new Vector3 );
      //}

        if (collision.gameObject.CompareTag("dirt"))//���ꂩ�ǂ����̃^�O���`�F�b�N
        {
            if (timer > timeBetweenShot) 
            {
                Destroy(gameObject);
            }
            
        }
    }
}

