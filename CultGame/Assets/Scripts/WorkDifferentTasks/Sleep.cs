using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : WorkTimer
{
    [SerializeField] int ContentBarRetraction;

    public override void CompletedTask()
    {
        tTest.content.SetBar(ContentBarRetraction );
        timerValue = 0;
    }
}
