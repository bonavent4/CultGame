using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityEditor.AI;
public class PeopleControll : MonoBehaviour
{
    NavMeshAgent navMesh;

    public GameObject building;
    public bool isWorking;

    [SerializeField] Animator anim;

    [SerializeField] bool isntWorking;
    float timeSinceLast;


    private void Awake()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
    }

    public void Work(GameObject workStation)
    {
        isntWorking = false;

        navMesh.SetDestination(workStation.transform.position);
        building = workStation;

        Walk();
    }
    private void Update()
    {
        if (!anim.GetBool("Dead"))
        {
            if (building != null && Vector3.Distance(transform.position, building.transform.position) < 6.5 && !isWorking)
            {
                building.GetComponent<WorkTimer>().peopleWorking++;
                isWorking = true;
                //isntWorking = false;

            }
            else if (isntWorking && timeSinceLast < Time.realtimeSinceStartup && !isWorking)
            {
                Walk();
                navMesh.SetDestination(new Vector3(Random.Range(gameObject.transform.position.x - 5, gameObject.transform.position.x + 5), 0, Random.Range(gameObject.transform.position.z - 5, gameObject.transform.position.z + 5)));
                timeSinceLast = Time.realtimeSinceStartup + Random.Range(0.5f, 8);
            }

            if (!isntWorking)
            {
                if (navMesh.velocity.normalized.x < .3f && navMesh.velocity.normalized.z < .3f && isWorking)
                {
                    if (!anim.GetBool("Work"))
                    {
                       // navMesh.SetDestination(gameObject.transform.position);
                        Work();
                    }

                }
                else if (anim.GetBool("Walk") == false && !anim.GetBool("Work"))
                {
                    Walk();
                }
            }
            if (isntWorking)
            {
                if (navMesh.velocity.normalized.x == 0 && navMesh.velocity.normalized.z == 0)
                {
                    StandStill();
                }
                else if (anim.GetBool("Walk") == false)
                {
                    Walk();
                }
            }
        }
        
        
        
    }

    public void StandStill()
    {
        if (!anim.GetBool("Idle"))
        {
            anim.SetBool("Work", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);


            isntWorking = true;
        }
        
    }
    public void Work()
    {
        if (!anim.GetBool("Work"))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Work", true);
            isntWorking = false;
        }
           
    }
    public void Walk()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Work", false);
        anim.SetBool("Walk", true);
    }

    public void Die()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Work", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Dead", true);
    }
}
