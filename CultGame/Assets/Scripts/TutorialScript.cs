using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    int tutorialStage = 0;
    public float tutorialTimer = 0;
    string[] tutorialQuestions = { "Hello, Priest\r\n\r\nPress [Tab] to open the building menu. Here, you will choose a building to place in the world.", "Place buildings in the world, and watch your underlings construct them. Buildings require stone and wood.\r\n\rPress [Space] to skip tutorials.", "This bar illustrates my appeasement with your cult. Keep it high, and i shall reward you. Let it become low, and i shall smite you.", "This bar illustrates the overall happiness of your underlings. If it falls to low, your underlings might leave you or even revolt.", "These are your resources. You will need stone and wood to make new buildings, and food to keep your underlings happy.", "This is your task bar. Tasks at the top will be prioritised, meaning more underlings will do the job. If the job is filled, excess underlings will then do other assignments." };
    [SerializeField] TextMeshProUGUI currentTutorial;
    public GameObject tutorialBackground;
    public GameObject[] tutorialArrows = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        currentTutorial.text = tutorialQuestions[tutorialStage];
    }

    // Update is called once per frame
    void Update()
    {
        print(tutorialTimer);
        if (Input.GetKeyDown(KeyCode.Tab) && tutorialStage < 1) 
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 1)
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 2)
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 3)
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 4)
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 5)
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }

        if (tutorialTimer < 20 && tutorialStage >= 1)
        {
            tutorialTimer += Time.deltaTime;
        }
        else if (tutorialTimer > 20 && tutorialStage >= 1)
        {
            tutorialTimer = 0;
            tutorialStage++;

            if (tutorialStage < 6) 
            {
                currentTutorial.text = tutorialQuestions[tutorialStage];
                
            }

        }
        if (tutorialStage >= 6)
        {
            Destroy(tutorialBackground);
            Destroy(currentTutorial);
        }
    }
}
