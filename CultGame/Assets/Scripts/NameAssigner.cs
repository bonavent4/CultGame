using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class NameAssigner : MonoBehaviour
{
    public TMP_InputField nameInputField; // Reference to the TMP_InputField UI element
    public TextMeshProUGUI displayText; // Reference to a TextMeshProUGUI object to display the assigned name

    private string assignedName = "Unnamed"; // Default assigned name

    // Getter and setter for assignedName
    public string AssignedName
    {
        get { return assignedName; }
        set { assignedName = value; }
    }

    // Function to set the assigned name when the player confirms the input
    public void SetName()
    {
        string newName = nameInputField.text;

        // Check if the input field is not empty
        if (!string.IsNullOrEmpty(newName))
        {
            // Display a confirmation dialog or perform any other confirmation process here
            // For now, let's assume we don't need a confirmation and set the name directly
            AssignedName = newName;
            displayText.text = "Assigned Name: " + AssignedName; // Update the display text
        }
        else
        {
            // Handle the case where the input field is empty
            Debug.Log("Please enter a valid name.");
        }
           
    }

    // Example usage
    private void Start()
    {
        // Example of how to access the assigned name
        Debug.Log("Assigned Name: " + AssignedName);
    }
}


