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

  [SerializeField]
  private float DelayBetweenChar = 0.1f;

  [SerializeField]
  private float DelayDoneWriting = 1f;

  [SerializeField]
  private bool StayWhenDoneWriting = true;

  [SerializeField]
  private GameObject CodecTextContainer;
  public IEnumerator WriteTextToObject(string inputText)
  {
    CodecTextContainer.SetActive(true);

    ClearText();

    DoneWriting = false;

    foreach (var ch in inputText)
    {
      TargetText.text += ch;
      yield return new WaitForSecondsRealtime(DelayBetweenChar);
    }
    DoneWriting = true;
    yield return new WaitForSecondsRealtime(2f);


    if (!StayWhenDoneWriting)
    {
      // ClearText();
      CodecTextContainer.SetActive(false);
    }
  }
  // Start is called before the first frame update

  void ClearText()
  {
    TargetText.text = "";
  }

  public bool IsDoneWriting()
  {
    return DoneWriting;
  }

  void SetStayWhenDoneWriting(bool b)
  {
    StayWhenDoneWriting = b;
  }

}
