using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public int tutorialStage = 0;
    public float tutorialTimer = 0;
    string[] tutorialQuestions = { "Hello, Priest\r\n\r\nI see you have decided to worship me. I appreciate that. You should start by clicking on a tree stump, which will send your cultists to harvest.", 
        "Now you have enough wood to build a town hall. Do this by clicking on the appropriate icon in the building menu, and then placing the blueprint in the world.", 
        "Good. You should now build a mine to aquire stone. When the mine is built, it will eventually be ready to harvest. The small icon above the mine will switch from orange to green when this happens.", 
        "Now that you have stone, you should build a praying stand. When you cilck on the stand, your cultists will begin a prayer session",
        "You should notice that this bar is increased when the prayer was complete. This bar represents my appeasement with your cult, and you should always try to keep it as high as possible. It must never be reduced to zero. Press [Space] to advance", 
        "This bar represents the happiness of your cultists. It will be reduced when your cultists do hard labor. To increase it, you must allow your cultists to relax. Build a bed and click on it to order a cultist to rest.", 
        "By now, you should have noticed the Task List. Everytime you order your cultists to do something, the task will appear here. If you want to prioritize a certain task, move it to the top of the list. Tasks will be prioritized based in vertical order, from highes to lowest." };
    
    string[] taskQuestions = { "Click on a tree to harvest wood, then use the wood to build a town hall", "Build a mine, then use the stone to build a prayer stand. You will also need wood" };

    [SerializeField] TextMeshProUGUI currentTutorial;
    [SerializeField] TextMeshProUGUI taskScroll;
    public GameObject tutorialBackground;
    [SerializeField] GameObject[] tutorialArrows = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
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
        //if (tutorialStage < 1)
        {
            taskScroll.text = taskQuestions[tutorialStage];

        }
        print(tutorialStage);
        //if (Input.GetKeyDown(KeyCode.Space) && tutorialStage < 1) 
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
            
        }
        //else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 1)
        {
            tutorialArrows[tutorialStage - 1].SetActive(false);
            tutorialStage++;
            tutorialArrows[tutorialStage - 1].SetActive(true);

            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;

        }
        //else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 2)
        {
            tutorialArrows[tutorialStage-1].SetActive(false);
            tutorialStage++;
            tutorialArrows[tutorialStage-1].SetActive(true);
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }
        //else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 3)
        {
            tutorialArrows[tutorialStage-1].SetActive(false);
            tutorialStage++;
            tutorialArrows[tutorialStage-1].SetActive(true);
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 4)
        {
 
            tutorialStage++;
          
        }
        //if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 5)
        {
            
            tutorialStage++;
            
            

        }
        //else if (Input.GetKeyDown(KeyCode.Space) && tutorialStage == 6)
        {
            tutorialStage++;
            currentTutorial.text = tutorialQuestions[tutorialStage];
            tutorialTimer = 0;

        }

        //if (tutorialTimer < 25 && tutorialStage >= 1)
        {
            tutorialTimer += Time.deltaTime;
        }
        //else if (tutorialTimer > 25 && tutorialStage >= 1)
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
        //if (tutorialStage >= 7)
        {
            Time.timeScale = 1;
            Destroy(tutorialBackground);
            Destroy(currentTutorial);
        }




    }

    public void IncreaseTutorialStage()
    {
        
        tutorialStage++;
        print(tutorialStage);

    }
}

public class tutorialProgressReference : MonoBehaviour
{
    public static TutorialScript tutorialscriptReference;

}
