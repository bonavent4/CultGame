using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotBuildBuildings : MonoBehaviour
{
    WorkCharacters workC;
    [SerializeField] int jobIndex;
    [SerializeField] int peopleNeededForThis;
    private void Awake()
    {
        workC = FindObjectOfType<WorkCharacters>();

        workC.UpdateList(jobIndex, peopleNeededForThis, gameObject);
    }

    
}
