using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildButton : MonoBehaviour
{
    public int maxAllowedBuildings;
    public int buildBuildings;
    ControllCharacters cChar;

    [SerializeField] int BuildingIndex;
    [SerializeField] int[] resourcesIndex;
    [SerializeField] int[] resourcesNeeded;

    [SerializeField] TextMeshProUGUI NumberOfBuildingsText;
    
    private void Awake()
    {
        cChar = FindObjectOfType<ControllCharacters>();
        check();
    }
    public void check()
    {
        if (maxAllowedBuildings == 0)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
        UpdateNumberText();
    }
    public void buttonClicked()
    {
        if(buildBuildings < maxAllowedBuildings)
        {
            cChar.ChooseBuilding(BuildingIndex, resourcesIndex, resourcesNeeded, gameObject);
        }
        
        
    }
    public void UpdateNumberText()
    {
        NumberOfBuildingsText.text = buildBuildings.ToString() + "/" + maxAllowedBuildings.ToString();
    }
}
