using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HaxorSim;
using Flag = HaxorSim.CodecTextController.CodecWriterFlags;
public class EventController : MonoBehaviour
{

  [SerializeField]
  private Flag currentEvent;

  [SerializeField]
  private GameObject HackingUI;

  [SerializeField]
  private CodecController CodecController;

  [SerializeField]
  private KeyWords KeyWordGenerator;

  [SerializeField]
  private bool StartTimer;

  [SerializeField]
  private float GameLength;

  [SerializeField]
  private float DefenseLength;

  [SerializeField]
  private float CurrentTime;

  [SerializeField]
  private float CurrentDefenseTime;

  [SerializeField]
  private Text ProgressBar;

  [SerializeField]
  private Text DefenseBar;

  private float LengthOfProgressBarSegment;

  private float LengthOfDefenseBarSegment;

  private SceneTransitions SceneTransitions;


  // Start is called before the first frame update
  void Start()
  {
    // KeyWordGenerator = ScriptableObject.CreateInstance<KeyWords>();
    CurrentTime = 0f;
    HackingUI.SetActive(false);
    currentEvent = Flag.Intro;
    CodecController.NotifyCodec(currentEvent);
    LengthOfProgressBarSegment = GameLength / 20f;
    LengthOfDefenseBarSegment = DefenseLength / 20f;
    CurrentDefenseTime = 0f;
    SceneTransitions = this.gameObject.AddComponent<SceneTransitions>();
  }

  void Update()
  {
    // Reached end of game
    if (CurrentTime >= GameLength)
    {
      SceneTransitions.SetSceneAsGoodEnd();
    }
    else if (CurrentDefenseTime >= DefenseLength)
    {
      SceneTransitions.SetSceneAsBadEnd();
    }
    if (StartTimer && CurrentTime < GameLength && CurrentDefenseTime < DefenseLength)
    {
      CurrentTime += Time.deltaTime;
      CurrentDefenseTime += Time.deltaTime;
      UpdateProgressBar();
      UpdateDefenseBar();
    }
  }

  public Flag GetCurrentEvent()
  {
    return currentEvent;
  }

  public void InitHackingUI()
  {
    HackingUI.SetActive(true);
    currentEvent = Flag.Gameplay;
    CodecController.NotifyCodec(Flag.Gameplay);
    StartTimer = true;
  }

  public void Notify(Flag flag)
  {
    CodecController.NotifyCodec(flag);
  }

  public string GenerateNewCommand(int x, int y)
  {
    return KeyWordGenerator.CreateCommand(x, y);
  }

  private void UpdateProgressBar()
  {
    // Num of full bars is totalTime / len of segment, rounded to nearest int.
    int numFullBars = (int)(CurrentTime / LengthOfProgressBarSegment);
    var newProgressBar = "[" + new string('=', numFullBars) + new string('-', 20 - numFullBars) + "]";
    ProgressBar.text = newProgressBar;
  }

  private void UpdateDefenseBar()
  {
    int numSmallerBars = (int)(CurrentDefenseTime / LengthOfDefenseBarSegment);
    var newProgressBar = "[" + new string('=', 20 - numSmallerBars) + new string('-', numSmallerBars) + "]";
    DefenseBar.text = newProgressBar;
  }

  public void ResetDefenseBar()
  {
    CurrentDefenseTime = 0f;
  }






  // Update is called once per frame
}
