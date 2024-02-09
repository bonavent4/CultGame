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
    public int peopleWorking = 4;
    public int workSize;
    public string peopleWorkingText;
    
    public Slider workSlider;
    // Start is called before the first frame update
    private void Awake()
    {
        workSlider = gameObject.GetComponent<Slider>();
    }
    void Start()
    {
 

    }

    // Update is called once per frame
    void Update()
    {
        timerValue += ((Time.deltaTime/ workSize * peopleWorking)*20);
        print(timerValue.ToString());
        if (timerValue >= 100) 
        {
            Destroy(gameObject);
        }

        workSlider.value = timerValue;

            
    }
}
