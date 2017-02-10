
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class settlement : MonoBehaviour
{
  private bool flag = true;

  void Update()
  {
    if (countManager.rebornCount1 == 0
      && hpManager.hp1 == 0.0f
      && countManager.downCount1 == 3
      && boxerState.Down1)
    {
      if (flag)
      {
        soundManager.Instance.PlaySE(1);
        soundManager.Instance.StopBGM();
        flag = false;
      }
    }
    if (countManager.rebornCount2 == 0
      && hpManager.hp2 == 0.0f
      && countManager.downCount2 == 3
      && boxerState.Down2)
    {
      if (flag)
      {
        soundManager.Instance.PlaySE(1);
        soundManager.Instance.StopBGM();
        flag = false;
      }
    }
  }
}
