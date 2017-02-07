
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class countManager : MonoBehaviour
{
  private static int downCount = 0;
  public static int GetDownCount() { return downCount; }

  public static int rebornCount1 = 2;
  public static int rebornCount2 = 2;

  float timeCount = 0.0f;

  void Update()
  {
    M(hpManager.hp1,
          inputManager.GetDownLeft1(),
          inputManager.GetDownRight1());

    M(hpManager.hp2,
      inputManager.GetDownLeft2(),
      inputManager.GetDownRight2());

    if (downCount >= 10)
    {
      timeCount += Time.deltaTime;
      if (timeCount >= 1.0f)
      {
        downCount = 0;
        timeCount = 0.0f;
      }
    }

    Debug.Log(downCount);
  }

  void M(float hp, bool f1, bool f2)
  {
    if (hp == 0.0f)
    {
      if (f1 || f2) { ++downCount; }
    }
  }
}
