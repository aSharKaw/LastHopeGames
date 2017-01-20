
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
    if (inputManager.GetDownRight1())
    {
      animator.SetBool("RightPunch", true);
      audioSource.Play();
    }
    else
    {
      animator.SetBool("RightPunch", false);
    }
  }
}
