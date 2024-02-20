using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour
{
    public Sprite[] highLightCubes = new Sprite[5];
    float pulseStage = 0;
    bool enlarge = true;
    TutorialScript tutReference;
    // Start is called before the first frame update
    void Start()
    {
        tutReference = FindObjectOfType<TutorialScript>();
    }

    // Update is called once per frame
    void Update()
    {
        while (enlarge == true)
        {
            pulseStage = Time.deltaTime;

             
            if (pulseStage > 2) 
            {
                enlarge = false;
            }
        }
    }
}
