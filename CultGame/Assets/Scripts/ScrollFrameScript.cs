using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollFrameScript : MonoBehaviour//, IPointerEnterHandler//, IPointerExitHandler//, EventTrigger
{

    [SerializeField] GameObject UpArrow;
    [SerializeField] GameObject DownArrow;
    bool clicked = false;
    //public Button m_YourFirstButton;
    // Start is called before the first frame update
    void Start()
    {
        //m_YourFirstButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(clicked);
       if (Input.GetMouseButtonDown(0) == true && clicked == true)
       {
            Debug.Log("Here");
            gameObject.GetComponent<Transform>().position += Vector3.up * 1;
       }else if (clicked == false && Input.GetMouseButtonDown(0) == false)
       {
              //clicked = false;
       }
       Debug.Log(clicked);
       Debug.Log(Input.GetMouseButtonDown(0));
    }

    public void uppressed()
    {
        clicked = true;
    }

    public void downpressed()
    {
        clicked = true;
        //ScrollObject.GetComponent<Transform>().position += Vector3.up * 80;
        Debug.Log(clicked);
    }
}
