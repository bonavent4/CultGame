using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationScript : MonoBehaviour
{

    [SerializeField] GameObject text;
    ResourceSystem resource;
    WorkCharacters wChar;
    
    // Start is called before the first frame update
    void Start()
    {
        resource = gameObject.GetComponent<ResourceSystem>();
        wChar = FindObjectOfType<WorkCharacters>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewDay()
    {
        text.transform.parent.gameObject.SetActive(true);
        float previous = resource.resources[0];
        resource.UpdateResource(0, -10 * wChar.Workers.Count);
        
        Time.timeScale = 0;
        text.GetComponent<TextMeshProUGUI>().text = "Food Loss: " + previous + " - " + (10 * wChar.Workers.Count).ToString();
      
    }
    public void startTimeAgain()
    {
        text.transform.parent.gameObject.SetActive(false);



        Time.timeScale = 1;
    }
}
