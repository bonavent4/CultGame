using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerTest : MonoBehaviour
{
    float time = 0;
    float Minutes = 0;
    public FavorBar favor;
    public FavorBar content;
    public WorkTimer timertest;
    public TextMeshProUGUI testText;
    [SerializeField] float multiplier;
    
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
            
        favor.SetBar(multiplier * Time.deltaTime);


    } 
}
