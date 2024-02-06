using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityList : MonoBehaviour
{
    [SerializeField] GameObject jobPrefab;
    [SerializeField] float maxYPosition;
    [SerializeField] float minYPostion;

    float offset = 0;
    [SerializeField] float plusToOffset;

    [SerializeField] List<GameObject> jobs;

    [SerializeField] float mouseScrollMultiplier;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject g = Instantiate(jobPrefab, gameObject.transform);
            g.transform.position += new Vector3(0, offset, 0);
            offset -= plusToOffset;
            jobs.Add(g);
            ResetJobs();
        }
        if (Input.mouseScrollDelta.y != 0)
        {
            if(gameObject.transform.position.y < (maxYPosition - offset -100) && Input.mouseScrollDelta.y > 0)
            {
                Debug.Log(Input.mouseScrollDelta.y);
                gameObject.transform.position += new Vector3(0, Input.mouseScrollDelta.y * mouseScrollMultiplier, 0);
            }
            else if (gameObject.transform.position.y > (minYPostion + 100) && Input.mouseScrollDelta.y < 0)
            {
                Debug.Log(Input.mouseScrollDelta.y);
                gameObject.transform.position += new Vector3(0, Input.mouseScrollDelta.y * mouseScrollMultiplier, 0);
            }

            ResetJobs();
           
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
