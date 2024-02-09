using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriorityList : MonoBehaviour
{
    [SerializeField] GameObject jobPrefab;
    [SerializeField] float maxYPosition;
    [SerializeField] float minYPostion;

    float offset = 0;
    [SerializeField] float plusToOffset;

    public List<GameObject> jobs;
    public List<int> People;
    [SerializeField] List<int> peopleAlreadyWorkingOnIt;
    public List<string> jobNames;
    public List<int> numberOfWorkStations;
    public List<GameObject> workStations;
    public List<int> workStationPeople;

    

    [SerializeField] float mouseScrollMultiplier;

    WorkCharacters wchar;

    private void Awake()
    {
        wchar = FindObjectOfType<WorkCharacters>();
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            if (gameObject.transform.position.y < (maxYPosition - offset - 100) && -Input.mouseScrollDelta.y > 0)
            {
               // Debug.Log(Input.mouseScrollDelta.y);
                gameObject.transform.position += new Vector3(0, -Input.mouseScrollDelta.y * mouseScrollMultiplier, 0);
            }
            else if (gameObject.transform.position.y > (minYPostion + 100) && -Input.mouseScrollDelta.y < 0)
            {
               // Debug.Log(Input.mouseScrollDelta.y);
                gameObject.transform.position += new Vector3(0, -Input.mouseScrollDelta.y * mouseScrollMultiplier, 0);
            }

            ResetJobs();

        }

    }
    public void AddJobToList(string jobName, int PeopleNeeded, GameObject WorkStation)
    {
        GameObject g = Instantiate(jobPrefab, gameObject.transform);

        offset -= plusToOffset;
        jobs.Add(g);
        People.Add(PeopleNeeded);
        jobNames.Add(jobName);
        workStations.Add(WorkStation);
        workStationPeople.Add(PeopleNeeded);
        numberOfWorkStations.Add(1);



        
        g.transform.position += new Vector3(0, offset, 0);
        // g.GetComponentInChildren<TextMeshProUGUI>().text =  "/" + PeopleNeeded + " " + jobName;
        UpdateAllNumbers();


        ResetJobs();
    }
   
    public void UpdateJobFromList(string jobName, int numberOfPeople, GameObject WorkStation)
    {
        int stations = 0;
        for (int i = 0; i < jobs.Count; i++)
        {
            stations += numberOfWorkStations[i];
            if (jobNames[i] == jobName)
            {
                People[i] += numberOfPeople;
                workStations.Insert(stations, WorkStation);
                workStationPeople.Insert(stations, numberOfPeople);
                numberOfWorkStations[i]++;
               // Debug.Log(stations);

                UpdateAllNumbers();
              //  jobs[i].GetComponentInChildren<TextMeshProUGUI>().text = "/" + People[i] + " " + jobName;
            }
        }
    }
    public void RemoveJobFromList(GameObject TheStation)
    {
        int workIndex = workStations.IndexOf(TheStation);
        //
        int numberOfStations = 0;
        int jobIndex = 0;

        for (int i = 0; i < jobs.Count; i++)
        {
            numberOfStations += numberOfWorkStations[i];
            if (workIndex <= numberOfStations)
            {
                jobIndex = i;
                break;
            }
        }
        
        
            People[jobIndex] -= workStationPeople[workIndex];
            numberOfWorkStations[jobIndex] -= 1;
            workStationPeople.Remove(workStationPeople[workIndex]);
            workStations.Remove(TheStation);


        if(numberOfWorkStations[jobIndex] == 0)
        {
            Destroy(jobs[jobIndex]);

            jobs.Remove(jobs[jobIndex]);
            People.Remove(People[jobIndex]);
            peopleAlreadyWorkingOnIt.Remove(peopleAlreadyWorkingOnIt[jobIndex]);
            jobNames.Remove(jobNames[jobIndex]);
            numberOfWorkStations.Remove(numberOfWorkStations[jobIndex]);
        }
        Debug.Log(workIndex);
        Debug.Log(jobIndex);
        UpdateAllNumbers();
        wchar.stopWorkersFromWorking();
        wchar.MakeWorkersWork();

        if(jobs.Count > 0 && jobIndex !> jobs.Count)
        {

        }

    }
    void UpdateAllNumbers()
    {
        peopleAlreadyWorkingOnIt = new List<int>();
        int usableWorkers = wchar.Workers.Count;
        for (int i = 0; i < People.Count; i++)
        {
            if(usableWorkers > People[i])
            {
                peopleAlreadyWorkingOnIt.Add(People[i]);
                usableWorkers -= People[i];
            }
            else
            {
                peopleAlreadyWorkingOnIt.Add(usableWorkers);
                usableWorkers = 0;
            }
            jobs[i].GetComponentInChildren<TextMeshProUGUI>().text = peopleAlreadyWorkingOnIt[i] + "/" + People[i] + " " + jobNames[i];
        }
    }
    
    void ResetJobs()
    {
        foreach (GameObject g in jobs)
        {
            if ((g.transform.position.y < minYPostion || g.transform.position.y > maxYPosition) && g.activeSelf)
            {
                g.SetActive(false);
            }
            else if (!g.activeSelf && g.transform.position.y > minYPostion && g.transform.position.y < maxYPosition)
            {
                g.SetActive(true);
            }
        }
    }
}
