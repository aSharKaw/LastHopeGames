
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pauseManager : MonoBehaviour
{
  private static bool pause = false;
  public static bool getPause => pause;

  void Update()
  {
    if (!pause)
    {
      if (inputManager.GetDownStart1() || inputManager.GetDownStart2())
      {
        pause = true;
      }
    }
    else
    {
      if (inputManager.GetDownStart1() || inputManager.GetDownStart2())
      {
        pause = false;
      }
    }
  }
}
