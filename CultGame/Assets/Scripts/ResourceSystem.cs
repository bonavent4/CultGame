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
    
    public List<float> resources;

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

    public int AddResource(float value)
      {
         resources.Add(value);
         return resources.Count;
      }
    public float UpdateResource(int pos, float value)
    {
        resources[pos-1] += value;
        return resources[pos-1];
    }
    public void SetResource(int pos, float value)
    {
        resources[pos-1] = value;
    }
    public float GetResource(int pos)
    {
        return resources[pos-1];
    }
}
