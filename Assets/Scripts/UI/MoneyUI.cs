using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [Header("Money Text")]
    public TextMeshProUGUI moneyText;

    private void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
