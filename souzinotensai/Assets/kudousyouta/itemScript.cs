using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour
{
    timeScript _timeScript;

    // Start is called before the first frame update
    void Start()
    {
        _timeScript = GameObject.Find("time").GetComponent<timeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            _timeScript.timer += 10;

            Destroy(gameObject);
        }
    }
}
