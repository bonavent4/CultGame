using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : WorkTimer
{
    [SerializeField] GameObject Worker;
    [SerializeField] Transform whereToPlaceWorker;
    public override void Awake()
    {
        wChar = FindObjectOfType<WorkCharacters>();

        base.Awake();
    }
    public override void DoneWithConstruction()
    {
        GameObject g = Instantiate(Worker, whereToPlaceWorker.transform.position, Quaternion.identity);
        wChar.Workers.Add(g);

        base.DoneWithConstruction();
    }
}
