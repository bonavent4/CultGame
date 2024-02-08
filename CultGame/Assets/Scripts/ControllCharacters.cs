using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEditor.AI;


public class ControllCharacters : MonoBehaviour
{
    

    RaycastHit hit;

    Camera cam;

    [SerializeField] LayerMask ignoreGreenLayer;

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

    public bool isTouchingBuilding;
    private void Awake()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (placeBuilding)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ignoreGreenLayer))
            {
                if (hit.transform.gameObject.CompareTag("Ground"))
                {
                    
                    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !isTouchingBuilding)
                    {
                        placeBuildings();
                    }
                    if(!Building.GetComponent<GreenBuilding>().child.activeSelf && !isTouchingBuilding)
                        Building.GetComponent<GreenBuilding>().child.SetActive(true);


                    gridPosition = new Vector2(Mathf.Round(hit.point.x / gridDistance) * gridDistance - gridXandZ[buildingToPlace].x, Mathf.Round(hit.point.z / gridDistance) * gridDistance - gridXandZ[buildingToPlace].y);

                    Building.transform.position = new Vector3(gridPosition.x, hit.point.y, gridPosition.y );
                    
                }
                else if(Building.GetComponent<GreenBuilding>().child.activeSelf)
                {
                    setBuildingInActive();
                }
            }
            else if (Building.GetComponent<GreenBuilding>().child.activeSelf)
            {
                setBuildingInActive();
            }

        }
       

        activateBuildMenu();
    }
    public void setBuildingInActive()
    {
        Building.GetComponent<GreenBuilding>().child.SetActive(false);
    }
    
    void placeBuildings()
    {

        Instantiate(notBuildBuildings[buildingToPlace], new Vector3(gridPosition.x, hit.point.y, gridPosition.y), Quaternion.identity);
       /* UnityEditor.AI.NavMeshBuilder.ClearAllNavMeshes();
        UnityEditor.AI.NavMeshBuilder.BuildNavMesh();*/
    }
    void activateBuildMenu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (buildingMenu.activeSelf)
            {
                buildingMenu.SetActive(false);
                Destroy(Building);
                isTouchingBuilding = false;
            }
            else
            {
                buildingMenu.SetActive(true);
                placeBuilding = false;
                Destroy(Building);
                isTouchingBuilding = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            placeBuilding = false;
            Destroy(Building);
            isTouchingBuilding = false;
        }
    }
    public void ChooseBuilding(int index)
    {
        buildingToPlace = index;
        placeBuilding = true;
        buildingMenu.SetActive(false);
        Building = Instantiate(buildingsGreen[index]);
        Building.GetComponent<GreenBuilding>().cc = gameObject.GetComponent<ControllCharacters>();
    }
}
