using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kudoitem : MonoBehaviour
{
    //プレイヤーを特定
    Transform playerTr;
    //敵のスピード調整
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
