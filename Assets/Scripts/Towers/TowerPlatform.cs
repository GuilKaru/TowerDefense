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
        //Get the renderer of the component to change it's color
        rend = GetComponent<Renderer>();
        rend.materials[1].color = platformColor;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        //Change color while hovering to show if you can build or not.
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
        //Change color back to normal
        rend.materials[1].color = platformColor;
    }

    private void OnMouseDown()
    {
        //Build tower if you have enough money
        if (!buildManager.CanBuild) return;

        if(EventSystem.current.IsPointerOverGameObject()) return;

        if(tower != null)
        {
            return;
        }

        buildManager.BuildTowerHere(this);
    }
}
