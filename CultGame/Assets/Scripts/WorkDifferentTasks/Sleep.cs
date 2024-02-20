using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : WorkTimer
{
    [SerializeField] int ContentBarRetraction;

    public override void CompletedTask()
    {
        tTest.content.SetBar(ContentBarRetraction );
        base.CompletedTask();

        if (tutorialProgressReference.tutorialscriptReference.tutorialStage == 5)
        {
            tutorialProgressReference.tutorialscriptReference.IncreaseTutorialStage();
        }
    }
}
