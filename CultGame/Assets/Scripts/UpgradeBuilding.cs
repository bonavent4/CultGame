using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeBuilding : MonoBehaviour
{
    ResourceSystem rSystem;

    [SerializeField] int[] resourcesIndex;
    [SerializeField] int[] resourcesAmount;

    [SerializeField] GameObject NewBuilding;

    GameObject upgradeM;
    private void Awake()
    {
        rSystem = FindObjectOfType<ResourceSystem>();
    }
    private void Update()
    {
        if(upgradeM != null && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab) || (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())))
        {
            upgradeM.SetActive(false);   
        }
    }
    public void OpenUpgradeMenu(GameObject upgradeMenu)
    {
        if (!upgradeMenu.activeSelf && gameObject.GetComponent<WorkTimer>().doneConstructing)
        {
            upgradeM = upgradeMenu;
            upgradeMenu.SetActive(upgradeMenu);
        }
        
    }
    public void ReplaceBuilding()
    {
        bool Replace = true;
        for (int i = 0; i < resourcesIndex.Length; i++)
        {
            if(rSystem.resources[resourcesIndex[i]] < resourcesAmount[i])
            {
                Replace = false;
            }
        }
        if (Replace)
        {
            upgradeM.SetActive(false);
            for (int i = 0; i < resourcesIndex.Length; i++)
            {
                rSystem.UpdateResource(resourcesIndex[i], -resourcesAmount[i]);
            }

            Instantiate(NewBuilding, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
