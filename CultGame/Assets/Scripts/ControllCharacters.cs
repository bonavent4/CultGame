using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEditor.AI;


public class ControllCharacters : MonoBehaviour
{
    //[SerializeField] NavMeshAgent navMeshAgent;

    RaycastHit hit;

    Camera cam;

    [SerializeField] GameObject[] buildings;
    [SerializeField] GameObject[] buildingsGreen;
    [SerializeField] GameObject[] notBuildBuildings;
    [SerializeField] Vector2[] gridXandZ;

    bool placeBuilding;
    [SerializeField] GameObject buildingMenu;
    int buildingToPlace;

    GameObject Building;

    [SerializeField] float gridDistance;
    Vector2 gridPosition;
    //[SerializeField] List<Vector2> PlacedBuildings;
    private void Awake()
    {
        cam = Camera.main;
    }
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
                    if(!Building.activeSelf)
                    Building.SetActive(true);

                    gridPosition = new Vector2(Mathf.Round(hit.point.x / gridDistance) * gridDistance - gridXandZ[buildingToPlace].x, Mathf.Round(hit.point.z / gridDistance) * gridDistance - gridXandZ[buildingToPlace].y);

                    Building.transform.position = new Vector3(gridPosition.x, hit.point.y, gridPosition.y );
                    
                }
                else if(Building.activeSelf)
                {
                    Building.SetActive(false);
                }
            }
            else if (Building.activeSelf)
            {
                Building.SetActive(false);
            }

        }
        /*else if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
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
        }*/

        activateBuildMenu();
    }

    void placeBuildings()
    {

        Instantiate(notBuildBuildings[buildingToPlace], new Vector3(gridPosition.x, hit.point.y, gridPosition.y), Quaternion.identity);
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
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            placeBuilding = false;
            Destroy(Building);
        }
    }
    public void ChooseBuilding(int index)
    {
        buildingToPlace = index;
        placeBuilding = true;
        buildingMenu.SetActive(false);
        Building = Instantiate(buildingsGreen[index]);
    }
}
