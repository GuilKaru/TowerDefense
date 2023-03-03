using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlatform : MonoBehaviour
{
    [Header("Tower in Platform")]
    public GameObject tower;

/*    [Header("Platform Material Colors")]
    public Material grassMaterial;*/

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.materials[1].color = Color.blue;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Did it entereeeed???");
        if (EventSystem.current.IsPointerOverGameObject()) return;

        rend.materials[1].color = Color.red;
    }

    private void OnMouseExit()
    {
        rend.materials[1].color = Color.blue;
    }
}
