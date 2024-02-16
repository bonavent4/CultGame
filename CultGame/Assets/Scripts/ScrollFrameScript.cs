using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollFrameScript : MonoBehaviour
{

    [SerializeField] GameObject UpArrow;
    [SerializeField] GameObject DownArrow;
    bool down = false;
    bool up = false;
    int multiplier = 1;
    bool scrolling = false;

    public GameObject[] BuildButtons;

    // Update is called once per frame
    void Update()
    {
        // Due to the event of the scroll wheel of the mouse, not being sent every frame,
        // this always makes sure that when the scroll wheel is sending an event to scroll,
        // it increases the significance of the movement for that singular scroll event, for that singular frame.
        // If it instead is the arrow buttons being held down, the multiplier is set back to default speed,
        // this is due to the every frame detecting the need for scroll as long as the buttons are held down, unlike scroll wheel events.
        if (Input.mouseScrollDelta.y != 0 && scrolling)
        {
            multiplier = 6;
        }else{
            multiplier = 1;
        }

        if (up || (Input.mouseScrollDelta.y == -1 && scrolling))
        {
           gameObject.GetComponent<Transform>().position += Vector3.up * 4 * multiplier;
        }else if (down || (Input.mouseScrollDelta.y == 1 && scrolling))
        {
           gameObject.GetComponent<Transform>().position -= Vector3.up * 4 * multiplier;
        }
    }

    // This activates when a button pointing upwards is being held down with a mouse input, and makes sure to disable the arrow downwards just in case.
    public void uppressed()
    {
        up = true;
        down = false;
    }

    // This deactivates the arrow pointing upwards when it is no longer being held down with the mouse input.
    public void upunpressed()
    {
        up = false;
    }

    // This activates when a button pointing downwards is being held down with mouse input, and makes sure to disable the arrow upwards just in case.
    public void downpressed()
    {
        down = true;
        up = false;
    }

    // This deactivates the arrow pointing downwards when it is no longer being held down with the mouse input.
    public void downunpressed()
    {
        down = false;
    }

    // This makes sure your mouse is currenty over the ui in question that needs to take input
    public void pointerenter()
    {
        scrolling = true; 
    }

    // This makes sure your mouse is no longer over the ui in question that needs to take input
    public void pointerexit()
    {
        scrolling = false; 
    }
}
