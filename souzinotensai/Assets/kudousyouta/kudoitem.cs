using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kudoitem : MonoBehaviour
{
    //�v���C���[�����
    Transform playerTr;
    //�G�̃X�s�[�h����
    [SerializeField] double speed = 1.5;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
