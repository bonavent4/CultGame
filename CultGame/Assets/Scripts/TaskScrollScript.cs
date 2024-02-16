using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskScrollScript : MonoBehaviour
{
    GameObject scroll;
    Sprite scrollunfolded;
    Sprite scrollfolded;
    TextMeshProUGUI scrollText;

    bool scrollIsUnfolded =true;

    // Start is called before the first frame update
    public void foldAndUnfoldScroll()
    {
        if (scrollIsUnfolded == true)
        {
            scroll.GetComponent<SpriteRenderer>().sprite = scrollfolded;

            scrollIsUnfolded = false;
        }

        if (scrollIsUnfolded == false) 
        {
            scroll.GetComponent<SpriteRenderer>().sprite = scrollunfolded;
            scrollIsUnfolded = true;
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
