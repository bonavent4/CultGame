using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : WorkTimer
{
    PriorityList list;

    [SerializeField] GameObject NotBuildBuilding;
    [SerializeField] GameObject buildBuilding;
    private void Awake()
    {
        list = FindObjectOfType<PriorityList>();
    }
    public override void CompletedTask()
    {
        NotBuildBuilding.SetActive(false);
        buildBuilding.SetActive(true);
        peopleWorking = 0;
        list.RemoveJobFromList(gameObject);
    }
}
