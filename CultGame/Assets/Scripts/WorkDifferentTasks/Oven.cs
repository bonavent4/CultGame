using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : WorkTimer
{
    
    [SerializeField] int ContentBarRetraction;

    [SerializeField] FoodMenu chooseFoodMenu;
    ResourceSystem rSystem;

    int foodAmount;
    public override void Awake()
    {
        rSystem = FindObjectOfType<ResourceSystem>();
        chooseFoodMenu = FindObjectOfType<FoodMenu>();
        base.Awake();


    }
    public override void CompletedTask()
    {
        tTest.content.SetBar(ContentBarRetraction);

        rSystem.UpdateResource(0, foodAmount);

        base.CompletedTask();
    }
    public override void StartTask()
    {
        //base.StartTask();
        //ReaddyForTask = true;
        if (ReaddyForTask && doneConstructing)
        {
            chooseFoodMenu.child.SetActive(true);
            chooseFoodMenu.Oven = gameObject;
        }
        
    }
    public void startMakingFood(int f)
    {
        foodAmount = f;

        wChar.UpdateList(newJobIndex, newPeopleNeeded, gameObject);
        ReaddyForTask = false;
        chooseFoodMenu.child.SetActive(false);
    }
}
