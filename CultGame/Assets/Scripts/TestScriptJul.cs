using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptJul : MonoBehaviour
{

    [SerializeField] ResourceSystem resource;
    // Start is called before the first frame update
    void Start()
    {
        int Stone = resource.AddResource(20);
        resource.UpdateResource(Stone,resource.GetResource(Stone)-5);
        Debug.Log(resource.GetResource(Stone));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
