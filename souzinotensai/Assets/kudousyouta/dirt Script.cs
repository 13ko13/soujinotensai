using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ������������̃^�O��Player���ǂ����𔻒�
        if ((collision.gameObject.tag == "Player"))
        {
            // Player�ł���Ύ������g��2�b��ɍ폜
            Destroy(this.gameObject, 0f);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
