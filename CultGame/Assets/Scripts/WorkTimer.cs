using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "WorkTimer", menuName = "ScriptableObjects/WorkTimer")]

public class WorkTimer : MonoBehaviour
{

    public float timerValue;
    public int peopleWorking;
    public int Multiplier;
    public int workSize;
    TutorialScript tutReference;

    [SerializeField] Slider workSlider;
    // [SerializeField] GameObject canvas;
    [SerializeField] GameObject ReadyIcon;

    protected PriorityList list;
    protected WorkCharacters wChar;

    [SerializeField] GameObject NotBuildBuilding;
    [SerializeField] protected GameObject buildBuilding;

    [SerializeField] protected int newJobIndex;
    [SerializeField] protected int newPeopleNeeded;

    public bool doneConstructing;
    [SerializeField] protected bool ReaddyForTask;

    protected TimerTest tTest;

    [SerializeField] int ContentConstructionRetraction;

    [SerializeField] AudioSource ConstructionSound;
    public virtual void Awake()
    {
        tTest = FindObjectOfType<TimerTest>();
        list = FindObjectOfType<PriorityList>();
        wChar = FindObjectOfType<WorkCharacters>();
        tutReference = FindObjectOfType<TutorialScript>();
    }


    public virtual void Update()
    {
        if (ReaddyForTask && doneConstructing && newJobIndex != 0)
        {
            if (!ReadyIcon.activeSelf)
            {
                ReadyIcon.SetActive(true);
            }
        }
        else if (ReadyIcon.activeSelf)
        {
            ReadyIcon.SetActive(false);
        }

        if (peopleWorking > 0)
        {
            if (!doneConstructing && !ConstructionSound.isPlaying)
                ConstructionSound.Play();

            if (!workSlider.gameObject.activeSelf)
                workSlider.gameObject.SetActive(true);

            timerValue += ((Time.deltaTime / workSize * peopleWorking) * Multiplier);
            //print(timerValue.ToString());
            if (timerValue >= 100)
            {
                if (doneConstructing)
                    CompletedTask();

                else
                    DoneWithConstruction();

                timerValue = 0;
            }

            workSlider.value = timerValue;
        }
        else if (workSlider.gameObject.activeSelf)
        {
            workSlider.gameObject.SetActive(false);

            if (ConstructionSound.isPlaying)
                ConstructionSound.Stop();
        }


        //  canvas.transform.LookAt(Camera.main.transform.position);
    }

    public virtual void DoneWithConstruction()
    {


        tTest.content.SetBar(ContentConstructionRetraction);
        NotBuildBuilding.SetActive(false);
        buildBuilding.SetActive(true);
        list.RemoveJobFromList(gameObject);




        doneConstructing = true;

        if (tutReference.tutorialStage == 1)
        {
            tutReference.IncreaseTutorialStage();
        }
    }
    public virtual void CompletedTask()
    {
        timerValue = 0;
        list.RemoveJobFromList(gameObject);
        ReaddyForTask = true;
    }
    public virtual void StartTask()
    {
        if (newJobIndex != 0 && doneConstructing && ReaddyForTask)
        {
            wChar.UpdateList(newJobIndex, newPeopleNeeded, gameObject);
            ReaddyForTask = false;

            if (tutReference.tutorialStage == 0)
            {
                tutReference.IncreaseTutorialStage();
            }

        }
    }

    
}
