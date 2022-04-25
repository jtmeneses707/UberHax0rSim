using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HaxorSim;
using ColorPalette = HaxorSim.ColorPalette.Colors; 
public class TerminalManager : MonoBehaviour
{

    [SerializeField]
    private GameObject directoryLine;

    [SerializeField]
    private GameObject repsonseLine;

    
    [SerializeField]
    private InputField userInputField;


    [SerializeField]
    private GameObject userInputLine;

    [SerializeField]
    private ScrollRect scrollRect;

    [SerializeField]
    private GameObject commandList;

    [SerializeField]
    private VerticalLayoutGroup verticalLayoutGroup;

    public void Start()
    {

        //userInputLine = userInputField.textComponent;
        
        //keyWords.CreateCommand()

    }

    // Creates events
    // Logic for user interacting with terminal

    private void Update()
    {
        //if (GUILayout.Button("Press Me"))
        //    Debug.Log("Hello!");
        //// Ensure that OnGUI can only be called once.
        ////if (Event.current.type != EventType.Repaint) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("PRESEED");
            ClearInputField();
            Debug.Log(userInputField.text);

        }

        if (userInputField.text != "" &&  Input.GetKeyDown(KeyCode.Return)) {

            // Stored Input Field
            var storedInput = userInputField.text;

            Debug.Log("Stored input" + storedInput);

            ClearInputField();

            // Create new directory line to mimic history of commands.
            AddCommandHistoryLine(storedInput);
            Debug.Log("PRessed");
    
        }
    }

    private void ClearInputField()
    {
        Debug.Log("CUrrent text is"+ directoryLine.GetComponentInChildren<Text>().text);
        //directoryLine.GetComponentInChildren<Text>().text = Time.time.ToString();
        userInputField.text = "";
    }

    // Create a command history line by adding in the user's input. 
    private void AddCommandHistoryLine(string userInput)
    {
        Debug.Log("Adding new line");
        // Size of the command entire command line.
        Vector2 commandListSize = commandList.GetComponent<RectTransform>().sizeDelta;

        // Get vertical spacing between each line in the vertical layout group
        var spacing = verticalLayoutGroup.spacing;
        // Get vertical height of a line of text. 
        var verticalHeight = directoryLine.GetComponent<RectTransform>().sizeDelta.y;
        // Grow the CommandLineContainer vertically
        commandList.GetComponent<RectTransform>().sizeDelta = new Vector2(commandListSize.x, commandListSize.y + spacing + verticalHeight);
        
        // Instantiate a new command history line.
        GameObject msg = Instantiate(directoryLine, commandList.transform);
        // Ensure new line is at end of vertical layout.
        msg.transform.SetSiblingIndex(commandList.transform.childCount - 1);

        // Set text of new Command history line.
        //msg.GetComponentInChildren<Text>()[1].text = userInputLine.text;
        msg.GetComponentsInChildren<Text>()[1].text = userInput;
    }


}

