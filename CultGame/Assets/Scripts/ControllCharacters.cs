using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class ControllCharacters : MonoBehaviour
{
    [SerializeField]NavMeshAgent navMeshAgent;

    RaycastHit hit;
    [SerializeField] float maxDistance;

    [SerializeField] Camera cam;

    [SerializeField] GameObject building;

    bool placeBuilding;
    [SerializeField] GameObject buildingMenu;
    GameObject buildingToPlace;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("Ground"))
                {
                    navMeshAgent.SetDestination(hit.point);
                    Debug.Log(hit.point);

                    placeBuildings();
                }
            }
        }

        activateBuildMenu();
    }

    void placeBuildings()
    {
        if(placeBuilding)
        Instantiate(building, hit.point, Quaternion.identity);
    }
    void activateBuildMenu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (buildingMenu.activeSelf)
            {
                buildingMenu.SetActive(false);
            }
            else
            {
                buildingMenu.SetActive(true);
                placeBuilding = false;
            }
        }
    }
    public void ChooseBuilding(int index)
    {
        placeBuilding = true;
        buildingMenu.SetActive(false);
    }
}
