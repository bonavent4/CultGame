using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
