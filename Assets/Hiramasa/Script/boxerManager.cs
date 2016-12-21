
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boxerManager : MonoBehaviour
{
  private Animator animator;

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (Input.GetButtonDown("TalconghaRight"))
    {
      animator.SetBool("RightPunch", true);
    }
    else
    {
      animator.SetBool("RightPunch", false);
    }
  }
}
