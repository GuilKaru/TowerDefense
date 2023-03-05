using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [Header("Health UI")]
    public TextMeshProUGUI healthText;

    private void Update()
    {
        healthText.text = PlayerStats.Lives.ToString();
    }
}
