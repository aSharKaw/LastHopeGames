
using UnityEngine;

public class countManager : MonoBehaviour
{
  public static int Count = 0; // 復帰に必要な叩く回数

  void Update()
  {
    M(hpManager.hp1,
      inputManager.GetDownLeft1(),
      inputManager.GetDownRight1());

    M(hpManager.hp2,
      inputManager.GetDownLeft2(),
      inputManager.GetDownRight2());
  }

  void M(float hp, bool f1, bool f2)
  {
    if (hp == 0.0f)
    {
      if (f1 || f2) { Count++; }
    }
  }
}
