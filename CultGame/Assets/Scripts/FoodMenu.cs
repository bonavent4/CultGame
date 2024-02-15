using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMenu : MonoBehaviour
{
    public GameObject Oven;

    [SerializeField] int[] FoodAmount;
    [SerializeField] int[] materialIndex;
    [SerializeField] int[] materialAmount;

    ResourceSystem rSystem;

    public GameObject child;

    private void Awake()
    {
        rSystem = FindObjectOfType<ResourceSystem>();
    }
    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab)) && child.activeSelf)
        {
            child.SetActive(false);
        }
    }
    public void MakeFood(int index)
    {
        
        if(rSystem.resources[materialIndex[index]] >= (-materialAmount[index]))
        {
            Debug.Log(rSystem.resources[materialIndex[index]] + " , " + (-materialAmount[index]));
            rSystem.UpdateResource(materialIndex[index], materialAmount[index]);
            // rSystem.UpdateResource(0, FoodAmount[index]);
            Oven.GetComponent<Oven>().startMakingFood(FoodAmount[index]);
        }
       
        
    }
}
