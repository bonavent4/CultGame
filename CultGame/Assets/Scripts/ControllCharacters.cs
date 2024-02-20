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
    TutorialScript tutReference;

    bool placeBuilding;
    //[SerializeField] GameObject buildingMenu;
    int buildingToPlace;

    GameObject Building;

    [SerializeField] float gridDistance;
    Vector2 gridPosition;
    //[SerializeField] List<Vector2> PlacedBuildings;

    public bool isTouchingBuilding;

    int[] resourceI;
    int[] resourceN;
    GameObject BuildButton;

    ResourceSystem rSystem;

    [SerializeField] GameObject upgradeMenu;
    GameObject buildingToUpgrade;
    private void Awake()
    {
        cam = Camera.main;
        rSystem = FindObjectOfType<ResourceSystem>();
        tutReference = FindObjectOfType<TutorialScript>();
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
                    if (hit.collider.gameObject.GetComponent<UpgradeBuilding>())
                    {
                        hit.collider.gameObject.GetComponent<UpgradeBuilding>().OpenUpgradeMenu(upgradeMenu);
                        buildingToUpgrade = hit.collider.gameObject;
                    }
                }
            }
        }
       

        activateBuildMenu();
    }

    public void UpgradeButton()
    {
        buildingToUpgrade.GetComponent<UpgradeBuilding>().ReplaceBuilding();
    }
    public void setBuildingInActive()
    {
        Building.GetComponent<GreenBuilding>().child.SetActive(false);
    }
    
    void placeBuildings()
    {
        BuildButton.GetComponent<BuildButton>().buildBuildings++;
        BuildButton.GetComponent<BuildButton>().UpdateNumberText();
        // rSystem.resources[resourceI] -= resourceN;
        // husk at opdatere resource texten;
        for (int i = 0; i < resourceI.Length; i++)
        {
            rSystem.UpdateResource(resourceI[i], -resourceN[i]);
        }
        bool toFewResources = false;
        for (int i = 0; i < resourceI.Length; i++)
        {
            if (rSystem.resources[resourceI[i]] < resourceN[i])
                toFewResources = true;
        }
        if (toFewResources || BuildButton.GetComponent<BuildButton>().maxAllowedBuildings == BuildButton.GetComponent<BuildButton>().buildBuildings)
        {
            placeBuilding = false;
            Destroy(Building);
            isTouchingBuilding = false;
        }
        Instantiate(notBuildBuildings[buildingToPlace], new Vector3(gridPosition.x, hit.point.y, gridPosition.y), Quaternion.identity);


    }

    void activateBuildMenu()
    {
        /* if (Input.GetKeyDown(KeyCode.Tab))
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
         }*/
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            placeBuilding = false;
            Destroy(Building);
            isTouchingBuilding = false;
        }
    }
    public void ChooseBuilding(int index, int[] resourceIndex, int[] resourcesNeeded, GameObject g)
    {
        BuildButton = g;
        resourceI = resourceIndex;
        resourceN = resourcesNeeded;
        placeBuilding = false;
        Destroy(Building);
        isTouchingBuilding = false;
        bool toFewResources = false;
        for (int i = 0; i < resourceI.Length; i++)
        {
            if (rSystem.resources[resourceI[i]] < resourceN[i])
                toFewResources = true;
        }
        if (!toFewResources)
        {
            buildingToPlace = index;
            placeBuilding = true;
           // buildingMenu.SetActive(false);
            Building = Instantiate(buildingsGreen[index]);
            Building.GetComponent<GreenBuilding>().cc = gameObject.GetComponent<ControllCharacters>();

            
        }
    }
    /*public void IndexResource(int resourceIndex)
    {
        resourceI = resourceIndex;
    }
    public void NeededResources(int resourcesNeeded)
    {
        resourceN = resourcesNeeded;
    }*/
}
