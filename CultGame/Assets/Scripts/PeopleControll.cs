using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor.AI;
public class PeopleControll : MonoBehaviour
{
    NavMeshAgent navMesh;

    public GameObject building;
    public bool isWorking;

    private void Awake()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
    }

    public void Work(GameObject workStation)
    {
        navMesh.SetDestination(workStation.transform.position);
        building = workStation;
    }
    private void Update()
    {
        if (building != null && Vector3.Distance(transform.position, building.transform.position) < 8 && !isWorking)
        {
            building.GetComponent<WorkTimer>().peopleWorking++;
            isWorking = true;
        }
    }
}
