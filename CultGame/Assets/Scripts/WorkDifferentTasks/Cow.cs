using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : WorkTimer
{
    ResourceSystem resource;
    [SerializeField] int ResourcePosition;
    [SerializeField] int plusToResource;
    [SerializeField] int berryIndex;
    [SerializeField] int berryAmount;

    [SerializeField] int ContentBarRetraction;

    [SerializeField] GameObject Coww;
    // [SerializeField] int GrownJobIndex;
    // [SerializeField] int GrownPeopleNeeded;

    Vector3 OriginalScale;
    [SerializeField] Vector3 SmallCowScale;
    //[SerializeField] Vector3 MiddleScale;
    //Vector3 ScaleGoal;

    bool growing;
    [SerializeField] float GrowingRate;

    [SerializeField] GameObject GrowingIcon;

    [SerializeField] AudioSource BushSlashTreeSound;

    public override void Awake()
    {
        base.Awake();
        resource = FindObjectOfType<ResourceSystem>();

        OriginalScale = Coww.transform.localScale;
    }
    public override void Update()
    {
        if (peopleWorking > 0 && !BushSlashTreeSound.isPlaying && doneConstructing)
        {
            BushSlashTreeSound.Play();
        }
        else if (peopleWorking == 0 && BushSlashTreeSound.isPlaying && doneConstructing)
        {
            BushSlashTreeSound.Stop();
        }
        Grow();

        base.Update();
    }
    void Grow()
    {
        if (growing)
        {
            Coww.transform.localScale += new Vector3(GrowingRate * Time.deltaTime, GrowingRate * Time.deltaTime, GrowingRate * Time.deltaTime);
            if (Coww.transform.localScale.y >= OriginalScale.y)
            {
                Coww.transform.localScale = OriginalScale;
                growing = false;
                ReaddyForTask = true;
                GrowingIcon.SetActive(false);
                //wChar.UpdateList(GrownJobIndex, GrownPeopleNeeded, gameObject);
            }
        }
    }
    void startGrowing()
    {
        
        Coww.transform.localScale = SmallCowScale;
        growing = true;
        GrowingIcon.SetActive(true);
    }
    void startFeeding()
    {
        resource.UpdateResource(- berryIndex, berryAmount);
    }
    public override void StartTask()
    {
        if (newJobIndex != 0 && doneConstructing && ReaddyForTask)
        {
            if(Coww.transform.localScale != OriginalScale && resource.resources[berryIndex] >= berryAmount)
            {
                startFeeding();
            }
            
            wChar.UpdateList(newJobIndex, newPeopleNeeded, gameObject);
            ReaddyForTask = false;
        }
    }
    public override void CompletedTask()
    {
        tTest.content.SetBar(ContentBarRetraction);
        //
        timerValue = 0;
        Debug.Log("Done");
        list.RemoveJobFromList(gameObject);
        if(Coww.transform.localScale == OriginalScale)
        {
            resource.UpdateResource(ResourcePosition, plusToResource);
            Coww.transform.localScale = SmallCowScale;
        }
        else
        {
            startGrowing();
        }
    }
}
