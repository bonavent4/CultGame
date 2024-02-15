using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : WorkTimer
{
    [SerializeField] GameObject Worker;
    [SerializeField] Transform whereToPlaceWorker;

    [SerializeField] int[] levelOneUnlocks;

    ScrollFrameScript sFScript;
    public override void Awake()
    {
        wChar = FindObjectOfType<WorkCharacters>();
        sFScript = FindObjectOfType<ScrollFrameScript>();

        base.Awake();
    }
    public override void DoneWithConstruction()
    {
        GameObject g = Instantiate(Worker, whereToPlaceWorker.transform.position, Quaternion.identity);
        wChar.Workers.Add(g);

        for (int i = 0; i < sFScript.BuildButtons.Length; i++)
        {
            sFScript.BuildButtons[i].GetComponent<BuildButton>().maxAllowedBuildings += levelOneUnlocks[i];
            sFScript.BuildButtons[i].transform.parent.gameObject.SetActive(true);
            sFScript.BuildButtons[i].GetComponent<BuildButton>().check();
        }

        base.DoneWithConstruction();
    }
}
