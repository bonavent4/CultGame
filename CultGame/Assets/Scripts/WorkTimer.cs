using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "WorkTimer", menuName = "ScriptableObjects/WorkTimer")]
public class WorkTimer : ScriptableObject
{
    int timerMax;
    int timerValue;
    int peopleWorking = 4;
    [SerializeField] int workSize;
    public string peopleWorkingText = "4";
    // Start is called before the first frame update
    void Start()
    {
        timerMax = 100;
        timerValue = 0;
        workSize = 3;

    }

    // Update is called once per frame
    void Update()
    {
        timerValue += ((int) Time.deltaTime)/ workSize * peopleWorking;

    }
}
