using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceSystem : MonoBehaviour
{

    
    enum myEnum 
    {
       Item1, 
       Item2, 
       Item3
    };// your custom enumeration
    
    public List<float> resources;
    [SerializeField] List<TextMeshProUGUI> resourceText;
    [SerializeField] List<string> resourceNames;

    // var dropDown = myEnum.Item1;  // this public var should appear as a drop down

    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < resourceText.Count; i++)
        {
            resourceText[i].text = resourceNames[i] + ": " + resources[i];
        }
    }
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
         return resources.Count-1;
      }
    public void UpdateResource(int pos, float value)
    {
        resources[pos] += value;

        resourceText[pos].text = resourceNames[pos] + ": " + resources[pos];

       // return resources[pos];
    }
    public void SetResource(int pos, float value)
    {
        resources[pos] = value;
    }
    public float GetResource(int pos)
    {
        return resources[pos];
    }
}
