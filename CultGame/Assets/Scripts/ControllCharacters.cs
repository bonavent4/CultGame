using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
//using UnityEditor.AI;


public class ControllCharacters : MonoBehaviour
{
    

    RaycastHit hit;

    Camera cam;

    [SerializeField] LayerMask ignoreGreenLayer;

    //[SerializeField] GameObject[] buildings;
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

    int resourceI;
    int resourceN;

    ResourceSystem rSystem;
    private void Awake()
    {
        cam = Camera.main;
        rSystem = FindObjectOfType<ResourceSystem>();
    }
    private void Update()
    {
        if (placeBuilding )
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
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.gameObject.GetComponent<WorkTimer>())
                    {
                        hit.collider.gameObject.GetComponent<WorkTimer>().StartTask();
                    }
                }
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
       // rSystem.resources[resourceI] -= resourceN;
        // husk at opdatere resource texten;
        rSystem.UpdateResource(resourceI ,-resourceN);

        Instantiate(notBuildBuildings[buildingToPlace], new Vector3(gridPosition.x, hit.point.y, gridPosition.y), Quaternion.identity);
       
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
        if (Input.GetKeyDown(KeyCode.Escape) || rSystem.resources[resourceI] < resourceN)
        {
            placeBuilding = false;
            Destroy(Building);
            isTouchingBuilding = false;
        }
    }
    public void ChooseBuilding(int index)
    {
        if(rSystem.resources[resourceI] >= resourceN)
        {
            buildingToPlace = index;
            placeBuilding = true;
            buildingMenu.SetActive(false);
            Building = Instantiate(buildingsGreen[index]);
            Building.GetComponent<GreenBuilding>().cc = gameObject.GetComponent<ControllCharacters>();

            
        }
    }
    public void IndexResource(int resourceIndex)
    {
        resourceI = resourceIndex;
    }
    public void NeededResources(int resourcesNeeded)
    {
        resourceN = resourcesNeeded;
    }
}
