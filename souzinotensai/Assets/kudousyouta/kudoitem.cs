using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kudoitem : MonoBehaviour
{
    
    //�v���C���[�����
    Transform playerTr;
    //�G�̃X�s�[�h����
    [SerializeField] float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�Ƃ̋�����0.1�����ɂȂ����炻��ȏ���s���Ȃ�

        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
        {

        }


        //�v���C���[�̕����ɂ���
        transform.position = Vector2.MoveTowards
            (transform.position, new Vector2(playerTr.position.x, playerTr.position.y), speed * Time.deltaTime);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))//�v���C���[���ǂ����̃^�O���`�F�b�N
        {
            
            
            Destroy(gameObject);
            

        }
    }
}

