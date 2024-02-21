using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCube : MonoBehaviour
{
    [SerializeField] float maxSize;
    [SerializeField] float minSize;
    bool direction = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.localScale.x < minSize)
        {
            direction = true;            
        }else if (gameObject.transform.localScale.x > maxSize)
        {
            direction = false;
        }

        if (direction)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x*(1 + Time.deltaTime/10), gameObject.transform.localScale.y*(1+Time.deltaTime/10), 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * (1 - Time.deltaTime/10), gameObject.transform.localScale.y * (1 - Time.deltaTime/10), 1);
        }
    }
}
