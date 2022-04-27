using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodecTextWriter : MonoBehaviour
{

  // Text field to write text to char by char.
  [SerializeField]
  private Text TargetText;

  [SerializeField]
  private bool DoneWriting;

  // private bool isRunning = false;

  [SerializeField]
  private float DelayBetweenChar = 0.1f;

  [SerializeField]
  private float DelayDoneWriting = 1f;


  [SerializeField]
  private GameObject CodecTextContainer;

  [SerializeField]
  private float DelayBeforeClear;

  [SerializeField]
  private bool WipeScreenAfterDelay;
  public IEnumerator WriteTextToObject(string inputText)
  {
    // if (DoneWriting)
    // {
    CodecTextContainer.SetActive(true);

    ClearText();

    DoneWriting = false;

    foreach (var ch in inputText)
    {
      TargetText.text += ch;
      yield return new WaitForSecondsRealtime(DelayBetweenChar);
    }
    DoneWriting = true;
    if (WipeScreenAfterDelay)
    {
      yield return new WaitForSecondsRealtime(DelayBeforeClear);
      CodecTextContainer.SetActive(false);
    }



    // }




  }
  // Start is called before the first frame update

  public void ClearText()
  {
    TargetText.text = "";
  }

  public bool IsDoneWriting()
  {
    return DoneWriting;
  }
}
