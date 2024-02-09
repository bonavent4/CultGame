using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEditor.AI;

public class WorkCharacters : MonoBehaviour
{
    ControllCharacters cc;
     PriorityList pList;

    
    RaycastHit hit;

    [SerializeField] string[] differnetJobs;
    [SerializeField] bool[] isOnList;

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
        MakeWorkersWork();

    }
    void MakeWorkersWork()
    {
        int totalNumberOfWorkStations = 0;
        foreach (int i in pList.numberOfWorkStations)
        {
            totalNumberOfWorkStations += i;
        }
        int workingStation = 0;
        int workersUsed = 0;
      //  for (int i = 0; i < pList.numberOfWorkStations.Count; i++)
      //  {
            for (int j = 0; j < totalNumberOfWorkStations; j++)
            {
                
                for (int k = 0; k < pList.workStationPeople[j]; k++)
                {
                    Debug.Log(k);
                    if (workersUsed == Workers.Count)
                    {
                       // Debug.Log("used up");
                        return;
                        
                    }
                    
                   
                    Workers[workersUsed].GetComponent<NavMeshAgent>().SetDestination(pList.workStations[workingStation].transform.position);
                    
                    workersUsed++;
                }
                workingStation++;
            }


       // }

        /*bool noMoreWorkLeft = false;
        List<int> PeopleWanted = new List<int>();
        foreach (int i in pList.People)
        {
            PeopleWanted.Add(i);
        }
        
        int number = 0;


        for (int i = 0; i < Workers.Count; i++)
        {
            if(number + 1 > PeopleWanted.Count)
            {
                noMoreWorkLeft = true;
            }
            else if (PeopleWanted[number] == 0 )
                number++;

            if(number + 1 <= PeopleWanted.Count && !noMoreWorkLeft)
            {
                Debug.Log(pList.jobNames[number]);

                PeopleWanted[number]--;

            }
            
        }*/

    }
}
