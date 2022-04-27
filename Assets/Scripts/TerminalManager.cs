using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HaxorSim;
// using ColorPalette = HaxorSim.ColorPalette.Colors;
using Flag = HaxorSim.CodecTextController.CodecWriterFlags;
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

  [SerializeField]
  private EventController EventController;

  [SerializeField]
  private string StringToMatch;

  [SerializeField]
  private CodecTextWriter CodecTextWriter;



  string RaisinBlack = "#62335";
  string Salmon = "#F27A70";
  string OldLace = "#FDF6EA";
  string RedSalsa = "#FD404A";
  string TurquoiseBlue = "#36F9ED";
  string Aquamarine = "#71EEB2";





  public void Start()
  {
    // userInputField.DeactivateInputField();
    // userInputField.enabled = false;
    RefocusInputField();
  }

  // Creates events
  // Logic for user interacting with terminal

  private void Update()
  {
    if (Input.anyKeyDown)
    {
      RefocusInputField();
    }

    if (EventController.GetCurrentEvent() == Flag.Intro)
    {

      if (userInputField.text != "" && Input.GetKeyDown(KeyCode.Return))
      {
        NormalizeUserInput();
        var storedInput = userInputField.text;
        // Gameplay loop for init hack start gane.
        if (EventController.GetCurrentEvent() == Flag.Intro)
        {

          if (StringMatches(storedInput, "hack start"))
          {
            StartHack();
            AddCommandHistoryLine(storedInput);
            StringToMatch = EventController.GenerateNewCommand();
            CreateResponseLine("New command: " + StringToMatch);
            FinishTerminalReturn();
          }
          else
          {
            BasicTerminalReturn();
          }

        }
      }
    }

    // Basic gameplay loop
    else if (Input.GetKeyDown(KeyCode.Return))
    {
      GameplayTerminalReturn();
    }
  }

  private void ClearInputField()
  {
    // Debug.Log("CUrrent text is" + directoryLine.GetComponentInChildren<Text>().text);
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
    // msg.transform.SetSiblingIndex(commandList.transform.childCount - 1);
    msg.transform.SetAsLastSibling();

    // SetInputFieldToBottom();

    // Set text of new Command history line.

    msg.GetComponentsInChildren<Text>()[1].text = userInput;
  }

  private void AddFailedHackResponse()
  {
    var str = $"<color={RedSalsa}>COMMAND HAS FAILED.</color>";
    CreateResponseLine(str);
  }

  private void AddSuccessfullHackResponse()
  {
    var str = $"<color={TurquoiseBlue}>COMMAND HAS SUCCEEDED.</color>";
    CreateResponseLine(str);
  }

  private void CreateResponseLine(string inputString)
  {
    Vector2 commandListSize = commandList.GetComponent<RectTransform>().sizeDelta;
    // Get vertical spacing between each line in the vertical layout group
    var spacing = verticalLayoutGroup.spacing;
    // Get vertical height of a line of text. 
    var verticalHeight = directoryLine.GetComponent<RectTransform>().sizeDelta.y;
    // Grow the CommandLineContainer vertically
    commandList.GetComponent<RectTransform>().sizeDelta = new Vector2(commandListSize.x, commandListSize.y + spacing + verticalHeight);
    GameObject msg = Instantiate(repsonseLine, commandList.transform);
    msg.GetComponentInChildren<Text>().text = inputString;
  }

  private void BasicTerminalReturn()
  {
    AddCommandHistoryLine(userInputField.text);
    FinishTerminalReturn();
  }

  // Function for the end of a terminal return. 
  // End of a terminal return is always setting the user input field back to the bottom.
  private void FinishTerminalReturn()
  {
    SetInputFieldToBottom();
    // Move scroll rect all the way down to bottom line
    ScrollToBottom();
    // Refocus the input field
    RefocusInputField();
    ClearInputField();
  }

  private void GameplayTerminalReturn()
  {
    AddCommandHistoryLine(userInputField.text);

    // TODO: NEED TO ADD RESPONSE FIELDS FOR FAILURE AND SUCCESS.
    if (StringMatches(StringToMatch, userInputField.text))
    {
      EventController.Notify(Flag.SuccessfulHack);
      AddSuccessfullHackResponse();
    }
    else
    {
      EventController.Notify(Flag.FailedHack);
      AddFailedHackResponse();
    }
    StringToMatch = EventController.GenerateNewCommand();
    CreateResponseLine("New command: " + StringToMatch);
    // Debug.Log("String to match" + StringToMatch);
    FinishTerminalReturn();
  }

  /** USEFUL HELPER FUNCTIONS **/

  private void GrowCommandLineContainer()
  {
    // Size of the command entire command line.
    Vector2 commandListSize = commandList.GetComponent<RectTransform>().sizeDelta;

    // Get vertical spacing between each line in the vertical layout group
    var spacing = verticalLayoutGroup.spacing;
    // Get vertical height of a line of text. 
    var verticalHeight = directoryLine.GetComponent<RectTransform>().sizeDelta.y;
    // Grow the CommandLineContainer vertically
    commandList.GetComponent<RectTransform>().sizeDelta = new Vector2(commandListSize.x, commandListSize.y + spacing + verticalHeight);
  }

  private void ScrollToBottom()
  {
    scrollRect.normalizedPosition = new Vector2(0, 0);
  }

  private void RefocusInputField()
  {
    userInputField.ActivateInputField();
    userInputField.Select();
  }

  private void NormalizeUserInput()
  {
    userInputField.text = userInputField.text.Trim();
  }

  private void SetInputFieldToBottom()
  {
    userInputLine.transform.SetAsLastSibling();
  }

  private void StartHack()
  {

    EventController.InitHackingUI();

  }

  private bool StringMatches(string str1, string str2)
  {
    if (str2 != str1)
    {
      return false;
    }
    return true;
  }
}

