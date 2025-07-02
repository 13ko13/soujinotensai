using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    [SerializeField] private Image hpBarImage;
    [SerializeField] private float maxHP = 5;
    private float currentHP;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0,maxHP);
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        float fill = currentHP / maxHP;
        hpBarImage.fillAmount = fill;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
