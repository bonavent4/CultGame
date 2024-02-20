using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : WorkTimer
{
    [SerializeField] GameObject Worker;
    [SerializeField] Transform whereToPlaceWorker;

    [SerializeField] int[] levelOneUnlocks;

    [SerializeField] ScrollFrameScript sFScript;
    [SerializeField] int numberOfPeopleToSpawn;
    public override void Awake()
    {
        wChar = FindObjectOfType<WorkCharacters>();
        sFScript = FindObjectOfType<ScrollFrameScript>();

        base.Awake();
    }
    public override void DoneWithConstruction()
    {
        for (int i = 0; i < numberOfPeopleToSpawn; i++)
        {
            GameObject g = Instantiate(Worker, whereToPlaceWorker.transform.position, Quaternion.identity);
            wChar.Workers.Add(g);
        }
        

        for (int i = 0; i < levelOneUnlocks.Length; i++)
        {
            sFScript.BuildButtons[i].GetComponent<BuildButton>().maxAllowedBuildings += levelOneUnlocks[i];
            sFScript.BuildButtons[i].transform.parent.gameObject.SetActive(true);
            sFScript.BuildButtons[i].GetComponent<BuildButton>().check();
        }
        timerValue = 0;

        base.DoneWithConstruction();
    }
}
