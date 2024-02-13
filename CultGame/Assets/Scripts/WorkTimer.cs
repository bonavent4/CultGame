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
    
    [SerializeField] Slider workSlider;
    [SerializeField] GameObject canvas;

    protected PriorityList list;
    protected WorkCharacters wChar;

    [SerializeField] GameObject NotBuildBuilding;
    [SerializeField] protected GameObject buildBuilding;

    [SerializeField] int JobIndex;
    [SerializeField] int newPeopleNeeded;

    [SerializeField] bool doneConstructing;

    protected TimerTest tTest;

    [SerializeField] int ContentConstructionRetraction;

    [SerializeField] AudioSource ConstructionSound;
    public virtual void Awake()
    {
        tTest = FindObjectOfType<TimerTest>();
        list = FindObjectOfType<PriorityList>();
        wChar = FindObjectOfType<WorkCharacters>();
    }
    /* private void Start()
     {
         int contentLoss;
         contentLoss = 0-(workSize / peopleWorking * 20);
         contentbar.SetContent(contentLoss);
     }*/

    public virtual void Update()
    {
        if (peopleWorking > 0)
        {
            if (!doneConstructing && !ConstructionSound.isPlaying)
                ConstructionSound.Play();
            
            if(!workSlider.gameObject.activeSelf)
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
        else if(workSlider.gameObject.activeSelf)
        {
            workSlider.gameObject.SetActive(false);

            if (ConstructionSound.isPlaying)
                ConstructionSound.Stop();
        }


        canvas.transform.LookAt(Camera.main.transform.position);
    }
    public virtual void DoneWithConstruction()
    {
        

        tTest.content.SetBar(ContentConstructionRetraction);
        NotBuildBuilding.SetActive(false);
        buildBuilding.SetActive(true);
        list.RemoveJobFromList(gameObject);

        if(JobIndex != 0)
        {
            wChar.UpdateList(JobIndex, newPeopleNeeded, gameObject);
        }
            

        doneConstructing = true;
    }
    public virtual void CompletedTask()
    {

    }

    public void ContentLoss()
    {


    }


}
