using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    [Header("Towers")]
    public GameObject StandardTowerPrefab;
    public GameObject SniperTowerPrefab;
    public GameObject BigTowerPrefab;

    private BuildTower buildTower;

    public bool CanBuild
    {
        get 
        { 
            return buildTower != null;
        }
    }

    public bool HasMoney
    { 
        get 
        { 
            return PlayerStats.Money >= buildTower.cost;
        } 
    }

    public void SetTowertoBuild(BuildTower tower)
    {
        Debug.Log("Do I enter here???");
        buildTower = tower;
    }

    public void BuildTowerHere(TowerPlatform platform)
    {
        //Return if the player doesn't have enough money to build a tower
        if(PlayerStats.Money < buildTower.cost)
        {
            Debug.Log("Not enough Money");
            return;
        }

        //Build Tower and pay its cost
        PlayerStats.Money -= buildTower.cost;

        GameObject Tower = Instantiate(buildTower.TowerPrefab, new Vector3(platform.transform.position.x, platform.transform.position.y + 0.2f, platform.transform.position.z), platform.transform.rotation);
        Tower.transform.SetParent(platform.transform);
        platform.tower = Tower;

        Debug.Log($"My money right now {PlayerStats.Money}");
    }
}
