using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBuildMenu : MonoBehaviour
{

    [SerializeField] GameObject button;
    [SerializeField] bool closed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter()
    {
        Debug.Log("Hi");
        button.GetComponent<Transform>().position = new Vector3(-106,31,0);
    }

    public void PointerExit()
    {
        Debug.Log("Bye");
        button.GetComponent<Transform>().position = new Vector3(-48, 31, 0);
    }
}
