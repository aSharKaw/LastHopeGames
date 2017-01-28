
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class countManager : MonoBehaviour
{
  [SerializeField]
  private static int count; // 増やすと復帰のときのカンストを減らす
  public static int getCount => count;

  void Update()
  {
    if (hpManager.hp1 == 0.0f)
    {
      if (inputManager.GetDownRight1()
      || inputManager.GetDownLeft1())
      {
        count++;
        Debug.Log($"count1 = {count}");
      }
    }

    if (hpManager.hp2 == 0.0f)
    {
      if (inputManager.GetDownRight2()
      || inputManager.GetDownLeft2())
      {
        count++;
        Debug.Log($"count2 = {count}");
      }
    }
  }
}
