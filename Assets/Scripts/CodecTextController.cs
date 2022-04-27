using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HaxorSim
{
  public class CodecTextController : MonoBehaviour
  {
    private string StartingText = "Let's take those corpos down down! You're a great hacker. You're ready for this. Type \'hack start\' whenever you're set...";

    private List<string> NegativeResponses = new List<string> {
    "I thought you were supposed to be great at this?", "What the hell happened?", "What a scrub...", "You've got to be kidding me...",
    "What a failure.", "So disappointing.", "What even was that?", "Ugh. Kinda cringe...", "Dude. Not cool.", "Not rad.", "That was the opposite of cool.",
    "Ugh ur a n00b.", "Uhhh? No?", "Do better."
  };

    private List<string> PositiveResponses = new List<string> {
    "That'll teach them!", "What a boss!", "This is epic.", "Go crazy!", "Just wow!", "Damn you might be even better than me...", "Holy crap!",
    "That was totally radical dude...", "Rad!", "Overkill!", "Like woah dude...", "Follow the white rabbit.", "You're in the zone!", "Keep it up!",
    "They didn't see that coming..."
  };



    [SerializeField]
    private CodecTextWriter CodecWriter;

    private Coroutine routine;

    public enum CodecWriterFlags
    {
      Intro, GoodEnd, BadEnd, FailedHack, SuccessfulHack, Gameplay,
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
      if (routine != null)
      {
        StopCoroutine(routine);
      }
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

        default:
          {
            textToWrite = "";
            break;
          }
          // case (CodecWriterFlag)
      }

      // Start writing text to object. 

      routine = StartCoroutine(CodecWriter.WriteTextToObject(textToWrite));
      // CoroutineRunning = false;
    }

    public string getIntroText()
    {
      return StartingText;
    }

    public bool IsDoneWriting()
    {
      return CodecWriter.IsDoneWriting();
    }

    public void ClearText()
    {
      CodecWriter.ClearText();
    }
  }
}

