using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GaugeController : MonoBehaviour
{
   // player _player;
    public Slider slider;
    public int GaugeNum;
    // Start is called before the first frame update
    void Start()
    {
     //   _player= GameObject.Find("player").GetComponent<player>();
        //UI
        slider.maxValue = 10;//_player.reload;
        slider.value = 0;//_player.cleaning;
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value = _player.cleaning;
        slider.value = GaugeNum;
    }
}
