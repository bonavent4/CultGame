using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] float time = 0;
    [SerializeField] string timeText;
    [SerializeField] float timeMultiplier;
    void Update()
    {
        time += Time.deltaTime * timeMultiplier;
        
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
        float Seconds = Mathf.Round(time) - 60 * Minutes;

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
        if (Seconds < 10)
        {
            inbetweens[2] = "0";
        }
        else
        {
            inbetweens[2] = "";
        }
        if (Hours < 10)
        {
            inbetweens[0] = "0";
        }
        else
        {
            inbetweens[0] = "";
        }


        timeText = inbetweens[0] + Hours.ToString() + ":" + inbetweens[1] + Minutes.ToString() + ":" + inbetweens[2] + Seconds.ToString();
    }
}
