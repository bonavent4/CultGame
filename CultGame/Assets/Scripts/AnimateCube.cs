using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCube : MonoBehaviour
{

    bool direction = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hi");
        if (gameObject.transform.localScale.x < 27)
        {
            direction = true;            
        }else if (gameObject.transform.localScale.x > 30)
        {
            direction = false;
        }

        if (direction)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x*(1 + Time.deltaTime), gameObject.transform.localScale.y*(1+Time.deltaTime), 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * (1 - Time.deltaTime), gameObject.transform.localScale.y * (1 - Time.deltaTime), 1);
        }
    }
}
