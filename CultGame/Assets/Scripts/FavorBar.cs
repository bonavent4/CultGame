using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FavorBar : MonoBehaviour
{
    public Slider favorSlider;
    public Slider contentSlider;
    public float currentFavor = 100;
    float favorLossMultiplier = 1;

    void Start()
    {
        favorSlider.value = 100;
    }

    // Start is called before the first frame update
    public void SetBar(float favor)
    {
        currentFavor -= favor; 
        
            favorSlider.value = Mathf.Round(currentFavor*favorLossMultiplier);
        
    }

    public void setLossMultiplier(int dayNumber)
    {
        favorLossMultiplier = 1+(dayNumber/20);

    }
   /* void Update()
    {

        currentFavor = favorSlider.value;

        favorSlider.value = currentFavor - Mathf.Round(Time.deltaTime);
    }*/

}
