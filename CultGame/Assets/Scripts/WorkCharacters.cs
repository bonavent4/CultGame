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

    [SerializeField] NavMeshAgent navMeshAgent;
    RaycastHit hit;

    [SerializeField] string[] differnetJobs;
    [SerializeField] bool[] isOnList;

    public List<GameObject> Workers;
    List<GameObject> placesToWork = new List<GameObject>();

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
            pList.AddJobToList(differnetJobs[jobIndex], extraPeopleNeeded);
            isOnList[jobIndex] = true;
        }
        else
        {
            pList.UpdateJobFromList(differnetJobs[jobIndex], extraPeopleNeeded);
            
        }
        placesToWork.Add(WhereToWork);
        MakeWorkersWork();

    }
    void MakeWorkersWork()
    {
        List<int> PeopleWanted = new List<int>();
        foreach (int i in pList.People)
        {
            PeopleWanted.Add(i);
        }
        
        int number = 0;
        for (int i = 0; i < Workers.Count; i++)
        {
            if (PeopleWanted[number] == 0)
                number++;

            Debug.Log(pList.jobNames[number]);
            Destroy(gameObject);
            //if()
            PeopleWanted[number]--;
        }
    }
}
