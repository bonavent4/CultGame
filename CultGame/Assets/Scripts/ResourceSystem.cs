using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : MonoBehaviour
{

    
    enum myEnum 
    {
       Item1, 
       Item2, 
       Item3
    };// your custom enumeration
    
    // var dropDown = myEnum.Item1;  // this public var should appear as a drop down

    // Start is called before the first frame update
    void Start()
    {

        //var dropDown = myEnum.Item1;  // this public var should appear as a drop down

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResource(string name)
      {
         Debug.Log("Adding resource");
      }
}
