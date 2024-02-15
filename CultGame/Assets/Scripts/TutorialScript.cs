using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    int tutorialStage = 0;
    public float tutorialTimer = 0;
    string[] tutorialQuestions = { "Hello, Priest\r\n\r\nThis is the building menu. Here, you will choose a building to place in the world. Press [Space] to skip tutorials.", "Place buildings in the world, and watch your underlings construct them. Buildings require stone and wood.", "This bar illustrates my appeasement with your cult. Keep it high, and i shall reward you. Let it become low, and i shall smite you.", "This bar illustrates the overall happiness of your underlings. If it falls to low, your underlings might leave you or even revolt.", "These are your resources. You will need stone and wood to make new buildings, and food to keep your underlings happy.", "This is your task bar. Tasks at the top will be prioritised, meaning more underlings will do the job. If the job is filled, excess underlings will then do other assignments.", "Some buildings allow interaction after construction. These buildings have a resource icon above them. Click on these buildings when the icon is green, and a job will be placed in the task bar" };
    [SerializeField] TextMeshProUGUI currentTutorial;
    public GameObject tutorialBackground;
    [SerializeField] GameObject[] tutorialArrows = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        currentTutorial.text = tutorialQuestions[tutorialStage];
       for (int i = 0; i < tutorialArrows.Length; i++)
        {
            if (i != 0)
            {
                tutorialArrows[i].SetActive(false);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        print(tutorialStage);
        if (Input.GetKeyDown(KeyCode.Space) && tutorialStage < 1) 
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 1)
        {
            tutorialArrows[tutorialStage - 1].SetActive(false);
            tutorialStage++;
            tutorialArrows[tutorialStage - 1].SetActive(true);

            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 2)
        {
            tutorialArrows[tutorialStage-1].SetActive(false);
            tutorialStage++;
            tutorialArrows[tutorialStage-1].SetActive(true);
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 3)
        {
            tutorialArrows[tutorialStage-1].SetActive(false);
            tutorialStage++;
            tutorialArrows[tutorialStage-1].SetActive(true);
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 4)
        {
            tutorialArrows[tutorialStage-1].SetActive(false);
            tutorialStage++;
            tutorialArrows[tutorialStage-1].SetActive(true);
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 5)
        {
            tutorialArrows[tutorialStage-1].SetActive(false);
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 6)
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;

        }

        if (tutorialTimer < 25 && tutorialStage >= 1)
        {
            tutorialTimer += Time.deltaTime;
        }
        else if (tutorialTimer > 25 && tutorialStage >= 1)
        {
            tutorialTimer = 0;

            tutorialStage++;

            if (tutorialStage < 7) 
            {


                
               tutorialArrows[tutorialStage-1].SetActive(false);
               tutorialArrows[tutorialStage].SetActive(true);
                

                currentTutorial.text = tutorialQuestions[tutorialStage];
                
            }


        }
        if (tutorialStage >= 7)
        {
            Destroy(tutorialBackground);
            Destroy(currentTutorial);
        }

    }
}
