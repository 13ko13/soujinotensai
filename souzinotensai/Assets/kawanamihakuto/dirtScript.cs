using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtScript : MonoBehaviour
{
    public GameObject Dirt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnDirt(Vector3 spawnPosition)
    {
        //�����ʒu�ɂ��铯���^�O�̃I�u�W�F�N�g��T��
        Collider[] colliders = Physics.OverlapSphere(spawnPosition, 0.01f);

        foreach(var col in colliders)
        {
            if(col.gameObject.CompareTag("dirt"))
            {
                //�Â��I�u�W�F�N�g������
                Destroy(col.gameObject);
                Debug.Log("�Â��I�u�W�F�N�g��������");
            }

        }

        //�V�����I�u�W�F�N�g�𐶐�
        GameObject newDirt = Instantiate(Dirt, spawnPosition, Quaternion.identity);
        newDirt.tag = "dirt";
        Debug.Log("�V�����I�u�W�F�N�g�𐶐�����");
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
         }
}

