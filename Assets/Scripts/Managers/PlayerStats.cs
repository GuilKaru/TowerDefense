using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    [Header("Player Stats")]
    [SerializeField] private int startMoney;
    [SerializeField] private int startLives;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
