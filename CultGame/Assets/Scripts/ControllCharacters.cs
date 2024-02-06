using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEditor.AI;


public class ControllCharacters : MonoBehaviour
{
    [SerializeField]NavMeshAgent navMeshAgent;

    RaycastHit hit;
    [SerializeField] float maxDistance;

    [SerializeField] Camera cam;

    [SerializeField] GameObject[] buildings;
    [SerializeField] GameObject[] buildingsGreen;
    [SerializeField] GameObject[] notBuildBuildings;

    bool placeBuilding;
    [SerializeField] GameObject buildingMenu;
    GameObject buildingToPlace;

    GameObject Building;
    private void Update()
    {
        if (placeBuilding)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("Ground"))
                {
                    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                    {
                        placeBuildings();
                    }
                    Building.transform.position = hit.point;

                }
            }
            
        }
        else if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.CompareTag("Ground"))
                {
                    navMeshAgent.SetDestination(hit.point);
                    Debug.Log(hit.point);

                }
            }
        }

        activateBuildMenu();
    }

    void placeBuildings()
    {
        
            Instantiate(buildingToPlace, hit.point, Quaternion.identity);
            UnityEditor.AI.NavMeshBuilder.ClearAllNavMeshes();
            UnityEditor.AI.NavMeshBuilder.BuildNavMesh();
    }
    void activateBuildMenu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (buildingMenu.activeSelf)
            {
                buildingMenu.SetActive(false);
                Destroy(Building);
            }
            else
            {
                buildingMenu.SetActive(true);
                placeBuilding = false;
                Destroy(Building);
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            placeBuilding = false;
            Destroy(Building);
        }
    }
    public void ChooseBuilding(int index)
    {
        buildingToPlace = notBuildBuildings[index];
        placeBuilding = true;
        buildingMenu.SetActive(false);
        Building = Instantiate(buildingsGreen[index]);
    }
}
