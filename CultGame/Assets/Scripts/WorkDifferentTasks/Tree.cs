using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : WorkTimer
{
    ResourceSystem resource;
    [SerializeField] int ResourcePosition;
    [SerializeField] int plusToResource;

    [SerializeField] int ContentBarRetraction;

    [SerializeField] GameObject plant;
    [SerializeField] AudioSource ChoppingTreeSound;

    public override void Awake()
    {
        base.Awake();
        resource = FindObjectOfType<ResourceSystem>();

    }
    public override void Update()
    {
        if(!ChoppingTreeSound.isPlaying && peopleWorking > 0 && doneConstructing)
        {
            ChoppingTreeSound.Play();
        }
        else if (ChoppingTreeSound.isPlaying && peopleWorking < 0 && doneConstructing)
        {
            ChoppingTreeSound.Stop();
        }
        base.Update();
    }
   

    public override void CompletedTask()
    {
        ChoppingTreeSound.Stop();
        tTest.content.SetBar(ContentBarRetraction);
        resource.UpdateResource(ResourcePosition, plusToResource);
        timerValue = 0;
        list.RemoveJobFromList(gameObject);
        Destroy(gameObject);

    }
}
