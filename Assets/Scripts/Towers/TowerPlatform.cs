using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlatform : MonoBehaviour
{
    [Header("Tower in Platform")]
    public GameObject tower;

    [Header("Tower Platform Colors")]
    public Color platformColor;
    public Color hoverColor;
    public Color noMoneyColor;

    private Renderer rend;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        rend.materials[1].color = platformColor;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Did it entereeeed???");
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if(!buildManager.HasMoney)
        {
            rend.materials[1].color = noMoneyColor;
        }
        else
        {
            rend.materials[1].color = hoverColor;
        }

    }

    private void OnMouseExit()
    {
        rend.materials[1].color = platformColor;
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
