using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLoadScene : MonoBehaviour
{
    private void Start()
    {
        Invoke("LoadScene", 7);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
