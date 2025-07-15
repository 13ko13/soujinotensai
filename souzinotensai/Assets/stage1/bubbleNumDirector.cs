using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bubbleNumDirector : MonoBehaviour
{
    public GameObject bubbleNum;
    public int bNum;
    // Start is called before the first frame update
    void Start()
    {
        bNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Text _bubbleNum = bubbleNum.GetComponent<Text>();

        _bubbleNum.text = "bubble:"+bNum;
    }
}
