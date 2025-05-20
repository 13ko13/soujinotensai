using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;
    public int dirt;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void TakeDamage()
    {
        currentHP -= 1;

        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject); 
    }
}
