using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    private TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();

        if (textMesh != null)
        {
            textMesh.text = "Ç±ÇÒÇ…ÇøÇÕÅAUnity!";
            textMesh.fontSize = 20;
            textMesh.color = Color.green;
            textMesh.anchor = TextAnchor.MiddleCenter;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
