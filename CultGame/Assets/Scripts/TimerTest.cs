using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    float time = 0;
    float Minutes = 0;
    public FavorBar favor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Minutes = Mathf.Round(Mathf.Round(time) / 60);
        time += Time.deltaTime;
        while (time >= 60)
        {
            
            favor.SetFavor((int) Mathf.Round(time));
        }
    }
}
