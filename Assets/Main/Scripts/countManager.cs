
using UnityEngine;

public class countManager : MonoBehaviour
{
  private static int inputCount = 0;
  public static int GetInputCount() { return inputCount; }

  public static int rebornCount1 = 2;
  public static int rebornCount2 = 2;

  public static int downCount1 = 0;
  public static int downCount2 = 0;

  float timeCount = 0.0f;

  void Update()
  {
    M(hpManager.hp1,
          inputManager.GetDownLeft1(),
          inputManager.GetDownRight1());

    M(hpManager.hp2,
      inputManager.GetDownLeft2(),
      inputManager.GetDownRight2());

    if (inputCount >= 10)
    {
      timeCount += Time.deltaTime;
      if (timeCount >= 1.0f)
      {
        inputCount = 0;
        timeCount = 0.0f;
      }
    }
  }

  void M(float hp, bool f1, bool f2)
  {
    if (hp == 0.0f)
    {
      if (f1 || f2) { ++inputCount; }
    }
  }
}
