using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBuilding : MonoBehaviour
{
    public ControllCharacters cc;
    List<GameObject> buildingsHit = new List<GameObject>();

    public GameObject child;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Building"))
        {
           // Debug.Log(other.gameObject.layer);
            cc.setBuildingInActive();
            cc.isTouchingBuilding = true;
            buildingsHit.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        buildingsHit.Remove(other.gameObject);
        if(buildingsHit.Count == 0)
        {
            cc.isTouchingBuilding = false;
            child.SetActive(true);
        }
    }

}
