using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GaugeController : MonoBehaviour
{
    player _player;


    public int maxgauge = 10;
    private int currentGauge;

    
    public Slider gaugeSlider;
    // Start is called before the first frame update
    void Start()
    {

        _player = GameObject.Find("player").GetComponent<player>();


        currentGauge = 0;
        gaugeSlider.maxValue = maxgauge;
        gaugeSlider.value = currentGauge;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
