using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBuildMenu : MonoBehaviour
{

    [SerializeField] GameObject button;
    bool closed = false;
    [SerializeField] GameObject buildMenu;
    [SerializeField] GameObject upArrow;
    [SerializeField] GameObject downArrow;
    bool mouseon = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (closed)
        {
            buildMenu.GetComponent<Transform>().localPosition = new Vector3(1072, 190, 0);
            upArrow.GetComponent<Transform>().localPosition = new Vector3(1072, 218, 0);
            downArrow.GetComponent<Transform>().localPosition = new Vector3(1072, -509, 0);
            if (mouseon)
            {
                button.GetComponent<Transform>().localPosition = new Vector3(936, -132, 0);
            }
            else
            {
                button.GetComponent<Transform>().localPosition = new Vector3(1000, -132, 0);
            }
        }else
        {
            buildMenu.GetComponent<Transform>().localPosition = new Vector3(848, 190, 0);
            upArrow.GetComponent<Transform>().localPosition = new Vector3(848, 218, 0);
            downArrow.GetComponent<Transform>().localPosition = new Vector3(848, -509, 0);
            if (mouseon)
            {
                button.GetComponent<Transform>().localPosition = new Vector3(725, -132, 0);
            }
            else
            {
                button.GetComponent<Transform>().localPosition = new Vector3(782, -132, 0);
            }
        }
    }

    public void PointerEnter()
    {
        mouseon = true;
    }

    public void PointerExit()
    {
        mouseon = false;
    }

    public void ButtonClick()
    {
        if (!closed)
        {
            closed = true;
        }
        else
        {
            closed = false;

        }
    }
}
