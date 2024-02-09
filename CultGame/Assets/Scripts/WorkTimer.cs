using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "WorkTimer", menuName = "ScriptableObjects/WorkTimer")]

public class WorkTimer : MonoBehaviour
{
    public int timerMax;
    public float timerValue;
    public int peopleWorking;
    public int workSize;
    public string peopleWorkingText;
    
    [SerializeField] Slider workSlider;
    [SerializeField] GameObject canvas;

    
    
    void Update()
    {
        if(peopleWorking > 0)
        {
            if(!workSlider.gameObject.activeSelf)
               workSlider.gameObject.SetActive(true);

            timerValue += ((Time.deltaTime / workSize * peopleWorking) * 20);
            //print(timerValue.ToString());
            if (timerValue >= 100)
            {
                CompletedTask();
            }

            workSlider.value = timerValue;
        }
        else if(workSlider.gameObject.activeSelf)
        {
            workSlider.gameObject.SetActive(false);
        }


        canvas.transform.LookAt(Camera.main.transform.position);
    }

    public virtual void CompletedTask()
    {

    }

    public void ContentLoss()
    {
        int contentLoss;
        contentLoss = workSize / peopleWorking*20;

        return contentLoss;

    }
}
