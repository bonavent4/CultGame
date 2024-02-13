using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationScript : MonoBehaviour
{

    [SerializeField] GameObject text;
    [SerializeField] DayAndNight Dayscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewDay()
    {
      text.GetComponent<TextMeshProUGUI>().text = "pizza";
    }
}
