﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boxerInput : MonoBehaviour
{
  private Animator animator;

  [SerializeField]
  private AudioClip audioClip;
  private AudioSource audioSource;

  void Start()
  {
    animator = GetComponent<Animator>();

    audioSource = GetComponent<AudioSource>();
    audioSource.clip = audioClip;
  }

  void Update()
  {
    if (!pauseManager.getPause)
    {
      
      if (inputManager.GetDownRight1() && !inputManager.GetDownLeft1())
      {
        animator.SetBool("RightPunch", true);
        audioSource.Play();
      }
      else
      {
        animator.SetBool("RightPunch", false);
      }
      if (inputManager.GetDownLeft1() && !inputManager.GetDownRight1())
      {
        animator.SetBool("LeftPunch", true);
        audioSource.Play();
      }
      else
      {
        animator.SetBool("LeftPunch", false);
      }
      if (inputManager.GetDownLeft1() && inputManager.GetDownRight1())
      {
        animator.SetBool("Guard", true);
        audioSource.Play();

        Debug.Log(123);
      }
      else
      {
        animator.SetBool("Guard", false);
      }

    }
  }
}
