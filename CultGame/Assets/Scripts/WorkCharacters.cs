using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
//using UnityEditor.AI;

public class WorkCharacters : MonoBehaviour
{
    ControllCharacters cc;
     PriorityList pList;

    
    RaycastHit hit;

    public string[] differnetJobs;
    public bool[] isOnList;

    public List<GameObject> Workers;

    private void Awake()
    {
        cc = gameObject.GetComponent<ControllCharacters>();
        pList = FindObjectOfType<PriorityList>();
    }
    private void Update()
    {
      /* if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
       {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           if (Physics.Raycast(ray, out hit, Mathf.Infinity))
           {
               if (hit.transform.gameObject.CompareTag("Ground"))
               {
                   navMeshAgent.SetDestination(hit.point);
                   Debug.Log(hit.point);

               }
           }
       }*/
    }
    public void UpdateList(int jobIndex, int extraPeopleNeeded, GameObject WhereToWork)
    {
        if (!isOnList[jobIndex])
        {
            pList.AddJobToList(differnetJobs[jobIndex], extraPeopleNeeded, WhereToWork);
            isOnList[jobIndex] = true;
        }
        else
        {
            pList.UpdateJobFromList(differnetJobs[jobIndex], extraPeopleNeeded, WhereToWork);
            
        }
        stopWorkersFromWorking();
        MakeWorkersWork();

    }
    public void MakeWorkersWork()
    {
        /*int totalNumberOfWorkStations = 0;
        foreach (int i in pList.numberOfWorkStations)
        {
            totalNumberOfWorkStations += i;
        }*/
        //int workingStation = 0;
        int workersUsed = 0;
            for (int i = 0; i < pList.jobs.Count; i++)
            {
                for (int j = 0; j < pList.jobs[i].GetComponent<JobPaper>().workStations.Count; j++)
                {
                     for (int k = 0; k < pList.jobs[i].GetComponent<JobPaper>().workStationPeople[j]; k++)
                     {
                         if (workersUsed == Workers.Count)
                         {
                             // Debug.Log("used up");
                             return;

                         }


                         // Workers[workersUsed].GetComponent<NavMeshAgent>()
                         Workers[workersUsed].GetComponent<PeopleControll>().Work(pList.jobs[i].GetComponent<JobPaper>().workStations[j]);

                         workersUsed++;
                     }
                }
               
            }
    }

    public void stopWorkersFromWorking()
    {
        for (int i = 0; i < Workers.Count; i++)
        {
            if (Workers[i].GetComponent<PeopleControll>().isWorking)
            {
                Workers[i].GetComponent<PeopleControll>().building.GetComponent<WorkTimer>().peopleWorking--;
                Workers[i].GetComponent<PeopleControll>().isWorking = false;
            }
            
            Workers[i].GetComponent<PeopleControll>().building = null;
            
            
        }
    }
}
