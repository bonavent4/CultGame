using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenScript : MonoBehaviour
{

    // Start is called before the first frame update



    public void SetEndScreen()
    {
        SceneManager.LoadScene("GameOver");

    }
}
