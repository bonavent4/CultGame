using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    int tutorialStage = 0;
    public float tutorialTimer = 0;
    string[] tutorialQuestions = { "Hello, Priest\r\n\r\nPress [Tab] to open the building menu. Here, you will choose a building to place in the world.", "Place buildings in the world, and watch your underlings construct them. Building requires stone and wood.", "This bar illustrates my appeasement with your gathering. Keep it high, and i shall reward you. Let it become low, and i shall smite you.", "This bar illustrates the overall happiness of your cultmembers. If it falls to low, your underlings might leave you or even revolt", "These are your resouces. You will need stone and wood to make new buildings, and food to keep your underlings happy", "This is your task bar. Tasks at the top will be prioritised, meaning more cultists do the job. If the job is filled, excess cultmembers will then do other assignments." };
    [SerializeField] TextMeshProUGUI currentTutorial;
    // Start is called before the first frame update
    void Start()
    {
        currentTutorial.text = tutorialQuestions[tutorialStage];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && tutorialStage < 1) 
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
        }

        if (tutorialTimer < 60 && tutorialStage >= 1)
        {
            tutorialTimer += Time.deltaTime;
        }
        else if (tutorialTimer > 60 && tutorialStage >= 1)
        {
            tutorialTimer = 0;
            tutorialStage++;

            if (tutorialStage < 6) 
            {
                currentTutorial.text = tutorialQuestions[tutorialStage];  
            }

        }

    }
}
