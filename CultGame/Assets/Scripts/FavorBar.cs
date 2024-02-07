using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavorBar : MonoBehaviour
{
    public Slider favorSlider;
    public Slider contentSlider;

    // Start is called before the first frame update
    public void SetFavor(int favor)
    {
        favorSlider.value = favor;
    }
    public void SetContent(int content)
    {
        contentSlider.value = content;
    }
}
