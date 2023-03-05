using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlatform : MonoBehaviour
{
    [Header("Tower in Platform")]
    public GameObject tower;

/*    [Header("Platform Material Colors")]
    public Material grassMaterial;*/

    private Renderer rend;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        rend.materials[1].color = Color.blue;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Did it entereeeed???");
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if(!buildManager.HasMoney)
        {
            rend.materials[1].color = Color.red;
        }
        else
        {
            rend.materials[1].color = Color.green;
        }

    }

    private void OnMouseExit()
    {
        rend.materials[1].color = Color.blue;
    }

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild) return;

        if(EventSystem.current.IsPointerOverGameObject()) return;

        if(tower != null)
        {
            return;
        }

        buildManager.BuildTowerHere(this);
    }
}
