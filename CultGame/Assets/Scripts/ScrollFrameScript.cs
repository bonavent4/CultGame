using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollFrameScript : MonoBehaviour //, IPointerDownHandler, IPointerUpHandler//, EventTrigger
{

    [SerializeField] GameObject UpArrow;
    [SerializeField] GameObject DownArrow;
    bool down = false;
    bool up = false;
    int multiplier = 1;
    bool scrolling = false;

    public GameObject[] BuildButtons;
    //public Button m_YourFirstButton;
    // Start is called before the first frame update
    void Start()
    {
        //m_YourFirstButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(clicked);
        if (Input.mouseScrollDelta.y != 0 && scrolling)
        {
            multiplier = 5;
        }else{
            multiplier = 1;
            //scrolling = false;
        }

       if (up || (Input.mouseScrollDelta.y == 1 && scrolling))
       {
            gameObject.GetComponent<Transform>().position += Vector3.up * 4 * multiplier;
       }else if (down || (Input.mouseScrollDelta.y == -1 && scrolling))
       {
       gameObject.GetComponent<Transform>().position -= Vector3.up * 4 * multiplier;
       }
       Debug.Log(Input.mouseScrollDelta.y);
    }

    public void uppressed()
    {
        up = true;
        down = false;
    }

    public void upunpressed()
    {
        up = false;
    }

    public void downpressed()
    {
        down = true;
        up = false;
    }

    public void downunpressed()
    {
        down = false;
    }

    public void pointerenter()
    {
        scrolling = true;
    }

    public void pointerexit()
    {
        scrolling = false;
    }
}
