using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bubbleNumDirector : MonoBehaviour
{
    public GameObject bubbleNum;
    public int b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text bubbleNum = GetComponent<Text>();

        bubbleNum.text = "bubble:"+b;
    }
}
