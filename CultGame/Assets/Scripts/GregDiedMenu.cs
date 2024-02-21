using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GregDiedMenu : MonoBehaviour
{
    [SerializeField] string[] names;
    [SerializeField] GameObject Menu;
    [SerializeField] TextMeshProUGUI deadText;
    public void PersonDied()
    {
        string name = names[Random.Range(0, names.Length)];

        Menu.SetActive(true);

        deadText.text = "- " + name + " - " +
            "Died Cause too little CultHappiness";
    }
    public void closeMenu()
    {
        Menu.SetActive(false);
    }
}
