using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationScript : MonoBehaviour
{

    [SerializeField] GameObject text;
    ResourceSystem resource;
    WorkCharacters wChar;
    TimerTest tTest;
    [SerializeField] GameObject ContentText;
    [SerializeField] float maxCultHLoss;
    
    // Start is called before the first frame update
    void Start()
    {
        resource = gameObject.GetComponent<ResourceSystem>();
        wChar = FindObjectOfType<WorkCharacters>();
        tTest = FindObjectOfType<TimerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewDay()
    {
        float foodRequired = wChar.Workers.Count * 10;
        if (resource.resources[0] < foodRequired)
        {
            foodRequired = resource.resources[0];
        }
        text.transform.parent.gameObject.SetActive(true);
        float previous = resource.resources[0];
        resource.UpdateResource(0, -foodRequired);
        
        tTest.content.SetBar(-((maxCultHLoss/ (wChar.Workers.Count * 10) * foodRequired) - maxCultHLoss));
        
        
        Time.timeScale = 0;
        text.GetComponent<TextMeshProUGUI>().text = "Food Loss: " + previous + " - " + (10 * wChar.Workers.Count).ToString();
        ContentText.GetComponent<TextMeshProUGUI>().text = "Cult Happiness Loss: " + ((maxCultHLoss / (wChar.Workers.Count * 10) * foodRequired) - maxCultHLoss).ToString();
    }
    public void startTimeAgain()
    {
        text.transform.parent.gameObject.SetActive(false);



        Time.timeScale = 1;
    }
}
