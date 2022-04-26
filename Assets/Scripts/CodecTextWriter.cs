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
  private float Delay = 0.1f;
  public IEnumerator WriteTextToObject(string inputText)
  {
    ClearText();
    DoneWriting = false;

    foreach (var ch in inputText)
    {
      TargetText.text += ch;
      yield return new WaitForSeconds(Delay);
    }

    yield return new WaitForSeconds(2f);
    DoneWriting = true;
  }
  // Start is called before the first frame update
  void Start()
  {
    ClearText();
    DoneWriting = true;
  }

  // Update is called once per frame
  void Update()
  {

  }

  void ClearText()
  {
    TargetText.text = "";
  }

  public bool IsDoneWriting()
  {
    return DoneWriting;
  }

}
