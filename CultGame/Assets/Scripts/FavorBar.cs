using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FavorBar : MonoBehaviour
{
    public Slider favorSlider;
    public Slider contentSlider;
    public float currentFavor;
    void Start()
    {
        favorSlider.value = 0;
    }

    // Start is called before the first frame update
    public void SetFavor(int favor)
    {
        favorSlider.value = favor;
    }
    public void SetContent(int content)
    {
        contentSlider.value = content;
    }
    void Update()
    {

        currentFavor = favorSlider.value;
    }
}
