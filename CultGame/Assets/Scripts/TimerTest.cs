using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class TimerTest : MonoBehaviour
{
    /*float time = 0;
    float Minutes = 0;*/
    public FavorBar favor;
    public FavorBar content;
    public WorkTimer timertest;
    public TextMeshProUGUI testText;
    [SerializeField] float FavorMultiplier;
    public float contentMultiplier;
    float favorLossMultiplier = 1;
    float dayMultiplier = 0;

    public int TotalNumberOfPeople;
    public int peopleWorking;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       // Minutes = Mathf.Round(Mathf.Round(time) / 60);
       // time -= Time.deltaTime * multiplier;



       // print(time);
            
        favor.SetBar((FavorMultiplier * Time.deltaTime)*favorLossMultiplier);
        if(content.currentFavor > 100)
        {
            content.currentFavor = 100;
        }
        if (favor.currentFavor > 100)
        {
            favor.currentFavor = 100;
        }







        /*  if(peopleWorking > 0)
          {
              content.SetBar(contentMultiplier * Time.deltaTime / TotalNumberOfPeople * peopleWorking);
          }*/



    }
    public void setLossMultiplier(int dayNumber)
    {

        favorLossMultiplier = 1 + (dayNumber / 20);

    }
}

public class setFavorlossReference : MonoBehaviour
{
    public static FavorBar referenceToFavorMultiplier;
    public static TimerTest testreference;


}
