using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBarSpawner : MonoBehaviour
{
    public GameObject barPrefab;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newBarprefab = Instantiate(barPrefab, canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBarprefab = Instantiate(barPrefab, canvas.transform);
            newBarprefab.transform.localPosition = new Vector3(-162, -134, 0);
            Debug.Log("test");
        }
        //newBarprefab.transform.SetParent(GameObject.FindGameObjectWithTag("aaa").transform, false);
        
    }

}
