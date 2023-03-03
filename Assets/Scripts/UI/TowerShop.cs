using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    [Header("Towers")]
    public BuildTower standardTower;
    public BuildTower sniperTower;
    public BuildTower bigTower;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void BuyStandardTower()
    {
        buildManager.SetTowertoBuild(standardTower);
    }

    public void BuySniperTower()
    {
        buildManager.SetTowertoBuild(sniperTower);
    }

    public void BuyBigTower()
    {
        buildManager.SetTowertoBuild(bigTower);
    }
}
