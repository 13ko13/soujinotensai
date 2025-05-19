using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // “–‚½‚Á‚½‘Šè‚Ìƒ^ƒO‚ªPlayer‚©‚Ç‚¤‚©‚ğ”»’è
        if ((collision.gameObject.tag == "Player"))
        {
            // Player‚Å‚ ‚ê‚Î©•ª©g‚ğ2•bŒã‚Éíœ
            Destroy(this.gameObject, 0f);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
