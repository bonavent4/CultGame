using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : WorkTimer
{
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
        base.CompletedTask();

        if (tutReference.tutorialStage == 3)
        {
            tutReference.IncreaseTutorialStage();
        }
    }


}
