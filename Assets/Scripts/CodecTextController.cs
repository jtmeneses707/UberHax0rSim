using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HaxorSim
{
  public class CodecTextController : MonoBehaviour
  {
    private string StartingText = "Let's take The Corporation down! You're a great hacker. You got this. Get ready. Type hack start whenever you're ready...";

    private List<string> NegativeResponses = new List<string> {
    "I thought you were supposed to be great at this!", "What the hell happened?", "What a scrub...", "You've got to be kidding me...",
    "What a failure."
  };

    private List<string> PositiveResponses = new List<string> {
    "That'll teach them!", "What a boss!", "This is epic.", "Go crazy!", "Just wow!", "Damn you might be even better than me"
  };



    [SerializeField]
    private CodecTextWriter CodecWriter;

    public enum CodecWriterFlags
    {
      Intro, GoodEnd, BadEnd, FailedHack, SuccessfulHack
    }

    void Start()
    {
      // Notify(CodecWriterFlags.Intro);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Notify the CodecTextController to start writing.
    // Flag is needed as context so that the Writer knows which text to write.
    public void Notify(CodecWriterFlags flag)
    {
      var textToWrite = "";
      switch (flag)
      {
        case (CodecWriterFlags.Intro):
          {
            textToWrite = StartingText;
            break;
          }
        case (CodecWriterFlags.FailedHack):
          {
            var ind = Random.Range(0, NegativeResponses.Count);
            textToWrite = NegativeResponses[ind];
            break;
          }
        case (CodecWriterFlags.SuccessfulHack):
          {
            var ind = Random.Range(0, PositiveResponses.Count);
            textToWrite = PositiveResponses[ind];
            break;
          }
      }

      // Start writing text to object. 
      StartCoroutine(CodecWriter.WriteTextToObject(textToWrite));
    }

    public string getIntroText()
    {
      return StartingText;
    }

    public bool IsDoneWriting()
    {
      return CodecWriter.IsDoneWriting();
    }
  }
}

