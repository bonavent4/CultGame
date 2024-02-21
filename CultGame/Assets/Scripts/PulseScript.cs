using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PulseScript : MonoBehaviour
{
    public GameObject[] highLightCubes = new GameObject[5];
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
            pulseStage += Time.deltaTime;
            highLightCubes[0].transform.localScale = new Vector3(1+pulseStage/8, 1+pulseStage/8, highLightCubes[0].transform.localScale.z);

             
            if (pulseStage > 2) 
            {
                enlarge = false;
            }
        }
        while (enlarge == false)
        {
            pulseStage -= Time.deltaTime;
            highLightCubes[0].transform.localScale = new Vector3(1 + pulseStage / 8, 1 + pulseStage / 8, highLightCubes[0].transform.localScale.z);

            if (pulseStage <= 0.1)
            {
                enlarge = true;
            }
        }
    }
}
