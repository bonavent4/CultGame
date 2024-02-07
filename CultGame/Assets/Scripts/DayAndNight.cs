using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] GameObject text; // The text
    [SerializeField] GameObject light; // The object that light is adjusted to with day night cycle
    [SerializeField] float time = 0; // The current time tracked in seconds
    [SerializeField] string timeText; // The text which displays the time in hours and minutes.
    [SerializeField] float nightIntervalInSeconds; // How many seconds the game intervals by each real second. This controls the in-game speed time relative to real time.
    [SerializeField] float dayIntervalInSeconds; // How many seconds the game interval by each second. This controls the in-game speed time relative to real time.
    [SerializeField] float dayStartHour; // The hour at which the time of day starts and the time of night ends.
    [SerializeField] float nightStartHour; // The hour at which the time of night starts and the time of day ends.
    public float fastForwardMultiplier = 1; // This multiplier can be used to fast forward time
    public float day = 0; // Tracking days
    public bool night = true; // Using a bool we track whether or not the current time of day is considered day or night. false = night, true = day
    void Update()
    {
        if (time >= nightStartHour*60*60 || time < dayStartHour*60*60)
        {
            night = true;
            time += Time.deltaTime * nightIntervalInSeconds * fastForwardMultiplier;
        }
        else
        {
            night = false;
            time += Time.deltaTime * dayIntervalInSeconds * fastForwardMultiplier;
        }
        
        float Minutes = Mathf.Round(Mathf.Round(time) / 60);
        if (Minutes * 60 > Mathf.Round(time))
        {
            Minutes -= 1;
        }
        float Hours = Mathf.Round(Minutes / 60);
        if (Hours * 60 > Minutes)
        {
            Hours -= 1;
        }
        if (time >= 86400)
        {
            time = 0;
            day +=1;
        }
        //float Seconds = Mathf.Round(time) - 60 * Minutes;

        Minutes -= Hours * 60;

        string[] inbetweens = new string[4];

        if(Minutes < 10)
        {
            inbetweens[1] = "0";
        }
        else
        {
            inbetweens[1] = "";
        }
        if (Hours < 10)
        {
            inbetweens[0] = "0";
        }
        else
        {
            inbetweens[0] = "";
        }

        float dayStart = (dayStartHour-1f)*60*60;
        float nightEnd = (dayStartHour+1f)*60*60;
        float nightStart = (nightStartHour-1f)*60*60;
        float dayEnd = (nightStartHour+1f)*60*60;
        float dayTime = 0.7f;

        if (time >= dayStart && time < nightEnd)
        {
            light.GetComponent<Light>().intensity = (time-dayStart)*dayTime/(nightEnd-dayStart);
        }
        else if (time >= nightStart && time < dayEnd)
        {
            light.GetComponent<Light>().intensity = dayTime-(time-nightStart)*dayTime/(dayEnd-nightStart);
        }
        

        timeText = inbetweens[0] + Hours.ToString() + ":" + inbetweens[1] + Minutes.ToString();
        text.GetComponent<TextMeshProUGUI>().text = timeText;
    }
}
