using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public int tutorialStage = 0;
    int tutorialStageCashe = 0;
    public float tutorialTimer = 0;
    string[] tutorialQuestions = { "Tutorial\r\n\r\nClick on a tree stump to order your cultists to harvest wood.", 
        "Build a town hall by clicking on the appropriate icon in the building menu, and then placing it in the world", 
        "Now build a mine to aquire stone. The small icon above the mine will switch from orange to green when it is ready to harvest",
        "This bar represents the happiness of your cultists. It will be reduced when your cultists do hard labor. To increase it, you must allow your cultists to relax. Build a bed and click on it to order a cultist to rest.",
        "Now that you have stone, you should build a praying stand. When you cilck on the stand, your cultists will begin a prayer session",
        "You should notice that this bar is increased when the prayer was complete. This bar represents my appeasemenPress [Space] to advance", 
        "By now, you should have noticed the Task List. Everytime you order your cultists to do something, the task will appear here. If you want to prioritize a certain task, move it to the top of the list. Tasks will be prioritized based in vertical order, from highes to lowest." };
    
    string[] taskQuestions = { "Click on a tree to harvest wood, then use the wood to build a town hall", "Build a mine, then use the stone to build a prayer stand. You will also need wood" };

    [SerializeField] TextMeshProUGUI currentTutorial;
    [SerializeField] TextMeshProUGUI taskScroll;
    public GameObject tutorialBackground;
    [SerializeField] GameObject[] tutorialArrows = new GameObject[5];
    [SerializeField] GameObject tutorialButton;
    bool tutorialIsShown = true;


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
        currentTutorial.text = tutorialQuestions[tutorialStage];

        tutorialArrows[tutorialStage].SetActive(true);
        

        if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 5)
        {
 
            tutorialStage++;
          
        }

        if (tutorialStage > 6)
        {
            Destroy(tutorialBackground);
            Destroy(currentTutorial);
            Destroy(tutorialButton);
        }
       

    }

    public void IncreaseTutorialStage()
    {
        
        tutorialStage++;
        for (int i = 0; i <= tutorialArrows.Length; i++)
        {
            if (i != tutorialStage)
            {
                tutorialArrows[i].SetActive(false);
            }

        }
        print(tutorialStage);

    }

    public void hideAndShowTutorial() 
    {
        if (tutorialIsShown == true)
        {
            tutorialBackground.SetActive(false);
            currentTutorial.color = new Color(currentTutorial.color.r, currentTutorial.color.g, currentTutorial.color.b, 0);
            tutorialStageCashe = tutorialStage;

            tutorialIsShown = false;
        }
        else if (tutorialIsShown == false) 
        {
            tutorialBackground.SetActive(true);
            currentTutorial.color = new Color(currentTutorial.color.r, currentTutorial.color.g, currentTutorial.color.b, 255);
   
            tutorialStage = tutorialStageCashe;
            tutorialArrows[tutorialStage].SetActive(true);
            tutorialIsShown = true;

        }

    }
}


