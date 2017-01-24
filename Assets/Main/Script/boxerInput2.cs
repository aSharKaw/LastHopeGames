
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boxerInput2 : MonoBehaviour
{
  private Animator anim;

  void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    // ポーズ中ならUpdate()を実行しない
    if (!pauseManager.getPause)
    {
      if (inputManager.GetDownRight2() && !inputManager.GetDownLeft2())
      {
        anim.SetBool("RightPunch2", true);
      }
      else
      {
        anim.SetBool("RightPunch2", false);
      }
      if (inputManager.GetDownLeft2() && !inputManager.GetDownRight2())
      {
        anim.SetBool("LeftPunch2", true);
      }
      else
      {
        anim.SetBool("LeftPunch2", false);
      }
      if (inputManager.GetDownLeft2() && inputManager.GetDownRight2())
      {
        anim.SetBool("Guard2", true);
      }
      else
      {
        anim.SetBool("Guard2", false);
      }
    }
  }
}
