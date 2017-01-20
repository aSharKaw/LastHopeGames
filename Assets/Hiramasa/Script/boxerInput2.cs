
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
    if (!pauseManager.getPause)
    {
      
      if (inputManager.GetDownRight2())
      {
        anim.SetBool("RightPunch2", true);
      }
      else
      {
        anim.SetBool("RightPunch2", false);
      }

    }
  }
}
