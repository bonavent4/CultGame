using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAdder : WorkTimer
{
    [SerializeField] ResourceSystem resource;
    public int stone;
    // Start is called before the first frame update
    void Start()
    {
        stone = resource.AddResource(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CompletedTask()
    {
        resource.UpdateResource(stone,+5);
    }
}
