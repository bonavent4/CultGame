using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : WorkTimer
{
    [SerializeField] ResourceSystem resource;
    [SerializeField] int ResourcePosition;
    [SerializeField] int plusToResource;

    [SerializeField] int ContentBarRetraction;

    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        resource = FindObjectOfType<ResourceSystem>();

    }
    public override void CompletedTask()
    {
        tTest.content.SetBar(ContentBarRetraction);
        resource.UpdateResource(ResourcePosition, plusToResource);
        timerValue = 0;
        Debug.Log("Done");
        list.RemoveJobFromList(gameObject);
        Destroy(gameObject);
    }
}
