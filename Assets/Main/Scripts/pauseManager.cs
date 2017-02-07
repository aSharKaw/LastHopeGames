
using UnityEngine;

public class pauseManager : MonoBehaviour
{
  private static bool pause = false;
  public static bool getPause() { return pause; }

  void Update()
  {
    // ポーズ中じゃなければ実行
    if (!pause)
    {
      if (inputManager.GetDownStart1()
        || inputManager.GetDownStart2())
      {
        pause = true;
      }
    }
    else
    {
      if (inputManager.GetDownStart1()
        || inputManager.GetDownStart2())
      {
        pause = false;
      }
    }
  }
}
