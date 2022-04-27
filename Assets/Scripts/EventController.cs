using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flag = HaxorSim.CodecTextController.CodecWriterFlags;
public class EventController : MonoBehaviour
{

  [SerializeField]
  private Flag currentEvent;

  [SerializeField]
  private GameObject HackingUI;

  [SerializeField]
  private CodecController CodecController;

  // Start is called before the first frame update
  void Start()
  {
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
  }




  // Update is called once per frame
}
