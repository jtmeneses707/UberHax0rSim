using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HaxorSim;
public class CodecController : MonoBehaviour
{
  [SerializeField]
  private CodecTextController CodecTextController;

  [SerializeField]
  private CodecTextWriter CodecTextWriter;

  [SerializeField]
  private float TimeToInitCodec;

  [SerializeField]
  private bool CodecReady;

  [SerializeField]
  private GameObject CodecContainer;

  [SerializeField]
  private float SecondsPerInterpolation;




  // Start is called before the first frame update
  void Start()
  {
    // StartCoroutine(OpenCodec());
    // CodecTextController.Notify(CodecTextController.CodecWriterFlags.Intro);

  }

  // Update is called once per frame
  void Update()
  {

  }

  public IEnumerator OpenCodec()
  {

    var totalTime = 0f;
    // float delay = TimeToInitCodec / this.NumOps;
    this.CodecContainer.transform.localScale = new Vector3(1, 0, 1);
    while (totalTime <= TimeToInitCodec)
    {
      var localScale = this.CodecContainer.transform.localScale;
      var newLocalScale = new Vector3(1, totalTime / TimeToInitCodec, 1);
      this.CodecContainer.transform.localScale = newLocalScale;
      totalTime += SecondsPerInterpolation;
      yield return new WaitForSecondsRealtime(SecondsPerInterpolation);
    }
    CodecReady = true;
  }

  public void NotifyCodec(CodecTextController.CodecWriterFlags flag)
  {
    // if (CodecReady)
    // {
    CodecTextController.Notify(flag);
    // }
  }


}
