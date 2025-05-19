using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //“GHP
    public int maxHP = 1;
    public int currentHP;

    private float time;
    private int vecX;
    private int vecY;
    void Start()
    {
        currentHP = maxHP;

        time = 4;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0.0f)
        {
            //0ˆÈã2–¢–ž‚Ì’l‚ªo‚Ü‚·
            if (Random.Range(0, 2) == 1)
            {
                if (Random.Range(0, 2) == 1)
                {
                    vecX = 1;

                }
                else
                {
                    vecX = -1;
                }

            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    vecY = 1;

                }
                else
                {
                    vecY = -1;
                }
            }



            transform.position = new Vector3(vecX, vecY, 0);
            time = 1.5f;
        }
        void TakeDamage()
        {
            currentHP -= 1;

            if (currentHP <= 0)
            {
                Die();
            }
        }
        void Die()
        {
            Destroy(gameObject);
        }
    }
}




