using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAdder : WorkTimer
{
    [SerializeField] ResourceSystem resource;
    [SerializeField] int ResourcePosition;
    [SerializeField] int plusToResource;

    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        resource = FindObjectOfType<ResourceSystem>();
        
    }

    

    public override void CompletedTask()
    {
        resource.UpdateResource(ResourcePosition, plusToResource);
        timerValue = 0;
        Debug.Log("Done");
    }
}
