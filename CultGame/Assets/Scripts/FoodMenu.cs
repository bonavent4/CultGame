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

    private void Awake()
    {
        rSystem = FindObjectOfType<ResourceSystem>();
    }
    public void MakeFood(int index)
    {
        rSystem.UpdateResource(materialIndex[index], materialAmount[index]);
        // rSystem.UpdateResource(0, FoodAmount[index]);
        Oven.GetComponent<Oven>().startMakingFood(FoodAmount[index]);
    }
}
