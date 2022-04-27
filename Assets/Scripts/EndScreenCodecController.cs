using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HaxorSim;
public class EndScreenCodecController : MonoBehaviour
{
  // Start is called before the first frame update

  [SerializeField]
  private Text CodecText;

  [SerializeField]
  private CodecTextController CodecTextController;

  [SerializeField]
  private int Type;

  void Start()
  {
    if (Type == 1)
    {
      CodecTextController.Notify(HaxorSim.CodecTextController.CodecWriterFlags.BadEnd);
    }
    else
    {
      CodecTextController.Notify(HaxorSim.CodecTextController.CodecWriterFlags.GoodEnd);
    }

  }
}
