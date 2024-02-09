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
    
    [SerializeField] Slider workSlider;
    [SerializeField] GameObject child;

    
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
 

    }

    // Update is called once per frame
    void Update()
    {
        if(peopleWorking > 0)
        {
            if(!child.activeSelf)
               child.SetActive(true);

            timerValue += ((Time.deltaTime / workSize * peopleWorking) * 20);
            //print(timerValue.ToString());
            if (timerValue >= 100)
            {
                Destroy(gameObject);
            }

            workSlider.value = timerValue;
        }
        else if(child.activeSelf)
        {
            child.SetActive(false);
        }


        gameObject.transform.LookAt(Camera.main.transform.position);
    }
}
