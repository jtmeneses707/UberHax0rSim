using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
  // Start is called before the first frame update
  public void SetSceneAsTerminal()
  {
    SceneManager.LoadScene(1);
  }

  public void SetSceneAsGoodEnd()
  {
    SceneManager.LoadScene(2);
  }

  public void SetSceneAsBadEnd()
  {
    SceneManager.LoadScene(3);
  }
}
