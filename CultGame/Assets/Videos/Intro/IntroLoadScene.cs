using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroLoadScene : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false;
    }
    private void Start()
    {
        Invoke("LoadScene", 7);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
