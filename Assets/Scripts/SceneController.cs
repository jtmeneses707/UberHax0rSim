using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
  private SceneTransitions SceneTransitions;
  // Start is called before the first frame update

  void Start()
  {
    SceneTransitions = this.gameObject.AddComponent<SceneTransitions>();
  }
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyUp(KeyCode.Space))
    {
      SceneTransitions.SetSceneAsTerminal();
    }
  }
}
