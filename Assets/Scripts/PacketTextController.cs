using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacketTextController : MonoBehaviour
{
  [SerializeField]
  private float BaseTimer;

  private float TimePassed;

  private Text TextObject;

  void Start()
  {
    TextObject = this.GetComponent<Text>();
    TimePassed = 0f;
    TextObject.text = GenerateRandomPacket();
    // if (BaseTimer) {
    //   BaseTimer = 2f;
    // }
  }

  // Update is called once per frame
  void Update()
  {
    TimePassed += Time.deltaTime;
    if (TimePassed >= BaseTimer + Random.Range(0, 1f))
    {
      // Debug.Log("Generating new hex");
      var hex = GenerateRandomPacket();
      // Debug.Log("Hex is" + hex);
      TextObject.text = hex;
      TimePassed = 0f;
    }
  }

  public string GenerateRandomPacket()
  {
    var packet = "";
    packet = GenerateRandomHexValue() + GenerateRandomHexValue();
    return packet;
  }


  private string GenerateRandomHexValue()
  {
    var i = Random.Range(0, 2);
    // Debug.Log("I is" + i);
    var hexVal = "";
    hexVal = (i == 0) ? ((char)Random.Range(65, 70)).ToString() : ((char)Random.Range(48, 57)).ToString();
    return hexVal;
  }

}
