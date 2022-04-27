using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

  // Start is called before the first frame update
  void Start()
  {
    // KeyWordGenerator = ScriptableObject.CreateInstance<KeyWords>();
    HackingUI.SetActive(false);
    currentEvent = Flag.Intro;
    CodecController.NotifyCodec(currentEvent);
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
  }

  public void Notify(Flag flag)
  {
    CodecController.NotifyCodec(flag);
  }

  public string GenerateNewCommand()
  {
    return KeyWordGenerator.CreateCommand();
  }






  // Update is called once per frame
}
