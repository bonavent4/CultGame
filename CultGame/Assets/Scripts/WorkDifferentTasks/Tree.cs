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
    // [SerializeField] int GrownJobIndex;
    // [SerializeField] int GrownPeopleNeeded;

    /*Vector3 OriginalScale;

    bool growing;
    [SerializeField] float GrowingRate;

    [SerializeField] GameObject GrowingIcon;*/

    public override void Awake()
    {
        base.Awake();
        resource = FindObjectOfType<ResourceSystem>();

        //OriginalScale = plant.transform.localScale;
    }
    public override void Update()
    {
       // Grow();

        base.Update();
    }
   /* void Grow()
    {
        if (growing)
        {
            plant.transform.localScale += new Vector3(GrowingRate * Time.deltaTime, GrowingRate * Time.deltaTime, GrowingRate * Time.deltaTime);
            if (plant.transform.localScale.y >= OriginalScale.y)
            {
                plant.transform.localScale = OriginalScale;
                growing = false;
                ReaddyForTask = true;
                GrowingIcon.SetActive(false);
                //wChar.UpdateList(GrownJobIndex, GrownPeopleNeeded, gameObject);
            }
        }
    }*/
    /*void startGrowing()
    {
        plant.transform.localScale = new Vector3(0, 0, 0);
        growing = true;
        GrowingIcon.SetActive(true);
    }*/
    /*public override void DoneWithConstruction()
    {
        

        base.DoneWithConstruction();
    }*/

    public override void CompletedTask()
    {
        tTest.content.SetBar(ContentBarRetraction);
        resource.UpdateResource(ResourcePosition, plusToResource);
        timerValue = 0;
        list.RemoveJobFromList(gameObject);
        Destroy(gameObject);

    }
}
