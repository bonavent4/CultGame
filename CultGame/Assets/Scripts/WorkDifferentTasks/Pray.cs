using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pray : WorkTimer
{
    [SerializeField] int prayAmount;
    [SerializeField] int ContentBarRetraction;
    TutorialScript tutReference;

    public override void Awake()
    {
        base.Awake();
        tutReference = FindObjectOfType<TutorialScript>();
       
    }
    public override void CompletedTask()
    {
        tTest.content.SetBar(ContentBarRetraction);
        tTest.favor.SetBar(prayAmount);
        base.CompletedTask();
    }
    public override void StartTask()
    {
        if (newJobIndex != 0 && doneConstructing && ReaddyForTask)
        {
            wChar.UpdateList(newJobIndex, newPeopleNeeded, gameObject);
            ReaddyForTask = false;

            if (tutReference.tutorialStage == 4)
            {
                tutReference.IncreaseTutorialStage();
            }


        }
    }
}
