using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PriorityList : MonoBehaviour
{
    [SerializeField] GameObject jobPrefab;
   /* [SerializeField] float maxYPosition;
    [SerializeField] float minYPostion;*/
    [SerializeField] Transform maxUp;
    [SerializeField] Transform maxDown;

    Vector2 ListStartPosition;

    float offset = 0;
    [SerializeField] float plusToOffset;

    public List<GameObject> jobs;
   /* public List<int> People;
    [SerializeField] List<int> peopleAlreadyWorkingOnIt;
    public List<string> jobNames;
    public List<int> numberOfWorkStations;
    public List<GameObject> workStations;
    public List<int> workStationPeople;*/

    

    [SerializeField] float mouseScrollMultiplier;

    WorkCharacters wchar;

    GameObject PaperToMoveUpAndDown;

    [SerializeField]List<GameObject> previousStations;
    private void Awake()
    {
        wchar = FindObjectOfType<WorkCharacters>();
        ListStartPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            if (gameObject.transform.position.y < (maxUp.position.y - offset - 100) && -Input.mouseScrollDelta.y > 0)
            {
               // Debug.Log(Input.mouseScrollDelta.y);
                gameObject.transform.position += new Vector3(0, -Input.mouseScrollDelta.y * mouseScrollMultiplier, 0);
            }
            else if (gameObject.transform.position.y > (maxDown.position.y + 100) && -Input.mouseScrollDelta.y < 0)
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
        JobPaper jPaper = g.GetComponent<JobPaper>();

        jobs.Add(g);

        jPaper.People += PeopleNeeded;
        jPaper.jobNames = jobName;

        jPaper.workStations.Add(WorkStation);
        jPaper.workStationPeople.Add(PeopleNeeded);
        

        g.transform.position += new Vector3(0, offset, 0);
        offset -= plusToOffset;

        UpdateAllNumbers();
        ResetJobs();
    }
   
    public void UpdateJobFromList(string jobName, int numberOfPeople, GameObject WorkStation)
    {
       // int stations = 0;
        for (int i = 0; i < jobs.Count; i++)
        {
           // stations += numberOfWorkStations[i];
            if (jobs[i].GetComponent<JobPaper>().jobNames == jobName)
            {
                JobPaper jPaper = jobs[i].GetComponent<JobPaper>();

                jPaper.People += numberOfPeople;
                jPaper.workStations.Add(WorkStation);
                jPaper.workStationPeople.Add(numberOfPeople);

                
            }
        }
        UpdateAllNumbers();
    }
    public void RemoveJobFromList(GameObject TheStation)
    {
        int workIndex = 0;
        int jobIndex = 0;

        for (int i = 0; i < jobs.Count; i++)
        {
            for (int k = 0; k < jobs[i].GetComponent<JobPaper>().workStations.Count; k++)
            {
                if(jobs[i].GetComponent<JobPaper>().workStations[k] == TheStation)
                {

                    workIndex = k;
                    jobIndex = i;
                }
            }
        }
        JobPaper jPaper = jobs[jobIndex].GetComponent<JobPaper>();

           jPaper.People -= jPaper.workStationPeople[workIndex];
           jPaper.workStationPeople.Remove(jPaper.workStationPeople[workIndex]);
           jPaper.workStations.Remove(TheStation);


        if(jPaper.workStations.Count == 0)
        {
            int stringIndex = 0;
            for (int i = 0; i < wchar.differnetJobs.Length; i++)
            {
                if(jPaper.jobNames == wchar.differnetJobs[i])
                {
                    stringIndex = i;
                    break;
                }
            }
            wchar.isOnList[stringIndex] = false;

            Destroy(jobs[jobIndex]);

            jobs.Remove(jobs[jobIndex]);

            ResetPositions();
        }
        UpdateAllNumbers();
        wchar.stopWorkersFromWorking();
        wchar.MakeWorkersWork();
    }

    void UpdateAllNumbers()
    {
        for (int i = 0; i < jobs.Count; i++)
        {
            jobs[i].GetComponent<JobPaper>().peopleAlreadyWorkingOnIt = 0;
        }

        int usableWorkers = wchar.Workers.Count;
        for (int i = 0; i < jobs.Count; i++)
        {
            JobPaper jPaper = jobs[i].GetComponent<JobPaper>();
            if (usableWorkers > jPaper.People)
            {
                jPaper.peopleAlreadyWorkingOnIt = jPaper.People;
                usableWorkers -= jPaper.People;
            }
            else
            {
                jPaper.peopleAlreadyWorkingOnIt = usableWorkers;
                usableWorkers = 0;
            }
            jobs[i].GetComponentInChildren<TextMeshProUGUI>().text = jPaper.peopleAlreadyWorkingOnIt + "/" + jPaper.People + " " + jPaper.jobNames;
        }
    }
    
    void ResetJobs()
    {
        foreach (GameObject g in jobs)
        {
            if ((g.transform.position.y < maxDown.position.y || g.transform.position.y > maxUp.position.y) && g.activeSelf)
            {
                g.SetActive(false);
            }
            else if (!g.activeSelf && g.transform.position.y > maxDown.position.y && g.transform.position.y < maxUp.position.y)
            {
                g.SetActive(true);
            }
        }
    }

    void ResetPositions()
    {
        offset = 0;
        for (int i = 0; i < jobs.Count; i++)
        {
            jobs[i].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + offset, 0);
            offset -= plusToOffset;
        }
    }

    public void MoveUp()
    {
        if(PaperToMoveUpAndDown != null && jobs.IndexOf(PaperToMoveUpAndDown) != 0)
        {
            int index = jobs.IndexOf(PaperToMoveUpAndDown);
            GameObject g = jobs[index];

            jobs.Remove(jobs[index]);
            jobs.Insert(index - 1, g);

          
            UpdateAllNumbers();
            wchar.stopWorkersFromWorking();
            wchar.MakeWorkersWork();
            ResetPositions();


            if (tutorialProgressReference.tutorialscriptReference.tutorialStage == 6)
            {
                tutorialProgressReference.tutorialscriptReference.IncreaseTutorialStage();
            }

        }
    }
    public void MoveDown()
    {
        if (PaperToMoveUpAndDown != null && jobs.IndexOf(PaperToMoveUpAndDown) != jobs.Count-1)
        {
            int index = jobs.IndexOf(PaperToMoveUpAndDown);
            GameObject g = jobs[index];

            jobs.Remove(jobs[index]);
            jobs.Insert(index + 1, g);


            UpdateAllNumbers();
            wchar.stopWorkersFromWorking();
            wchar.MakeWorkersWork();
            ResetPositions();

        }
    }
    public void OnButton(GameObject Paper)
    {
        for (int i = 0; i < jobs.Count; i++)
        {
            jobs[i].GetComponentInChildren<JobUI>().BackGround.enabled = false;
        }
        Paper.GetComponent<JobUI>().BackGround.enabled = true;
        PaperToMoveUpAndDown = Paper.transform.parent.gameObject;
    }
}
