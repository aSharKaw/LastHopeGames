
using UnityEngine;

public class boxerInput2 : MonoBehaviour
{
  private Animator anim;

  void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    // 左パンチ
    if (inputManager.GetDownLeft2()
      && !inputManager.GetDownRight2())
    {
      if (!boxerState.Left2 && !boxerState.Down2 && !boxerState.Down1)
      {
        anim.SetBool("Left", true);
        soundManager.Instance.PlaySE(5);
      }
    }
    else { anim.SetBool("Left", false); }

    // 右パンチ
    if (inputManager.GetDownRight2()
      && !inputManager.GetDownLeft2())
    {
      if (!boxerState.Right2 && !boxerState.Down2 && !boxerState.Down1)
      {
        anim.SetBool("Right", true);
        soundManager.Instance.PlaySE(4);
      }
    }
    else { anim.SetBool("Right", false); }

    // ガード
    if (inputManager.GetDownLeft2()
      && inputManager.GetDownRight2())
    {
      anim.SetBool("Guard", true);
    }
    else { anim.SetBool("Guard", false); }

    // カウンター
    if (inputManager.GetDownLeft2()
      || inputManager.GetDownRight2())
    {
      if (boxerState.Guard1)
      {
        anim.SetBool("CounterRight", true);
      }
    }
    else { anim.SetBool("CounterRight", false); }

    // ダウン
    if (hpManager.hp2 <= 0.0f)
    {
      anim.SetBool("Down", true);
    }
    else { anim.SetBool("Down", false); }
  }
}
