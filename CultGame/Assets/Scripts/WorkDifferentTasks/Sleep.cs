using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : WorkTimer
{
    [SerializeField] int ContentBarRetraction;
    TutorialScript tutReference;

    private void Awake()
    {
        tutReference = FindObjectOfType<TutorialScript>();
    }

    public override void CompletedTask()
    {
        tTest.content.SetBar(ContentBarRetraction );
        base.CompletedTask();

        if (tutReference.tutorialStage == 0)
        {
            tutReference.IncreaseTutorialStage();
        }
    }


}
