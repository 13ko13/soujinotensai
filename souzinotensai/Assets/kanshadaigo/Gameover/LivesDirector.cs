using TMPro; // TextMeshPro—p
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    private void Update()
    {
        if (GameManager.Instance != null)
        {
            livesText.text = "Lives: " + GameManager.Instance.lives.ToString();
        }
    }
}
