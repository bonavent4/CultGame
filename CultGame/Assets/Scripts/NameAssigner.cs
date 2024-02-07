using UnityEngine;
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
        AssignedName = nameInputField.text;
        displayText.text = "Assigned Name: " + AssignedName; // Update the display text
    }

    // Example usage
    private void Start()
    {
        // Example of how to access the assigned name
        Debug.Log("Assigned Name: " + AssignedName);
    }
}


