
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boxerInput : MonoBehaviour
{
  private Animator anim;

  [SerializeField]
  private AudioClip audioClip;
  private AudioSource audioSource;

  void Start()
  {
    anim = GetComponent<Animator>();

    audioSource = GetComponent<AudioSource>();
    audioSource.clip = audioClip;
  }

  void Update()
  {
    // ポーズ中ならUpdate()を実行しない
    if (!pauseManager.getPause)
    {
      anim.SetBool("Counter", false);
      anim.SetBool("RightPunch", false);
      anim.SetBool("LeftPunch", false);
      anim.SetBool("Guard", false);

      // 左パンチ
      if (inputManager.GetDownLeft1()
        && !inputManager.GetDownRight1()
        && !boxerState.GetBoxerState2.IsName("Base Layer.Guard"))
      {
        anim.SetBool("LeftPunch", true);
        audioSource.Play();
      }
      // 右パンチ
      if (inputManager.GetDownRight1()
        && !inputManager.GetDownLeft1()
        && !boxerState.GetBoxerState2.IsName("Base Layer.Guard"))
      {
        anim.SetBool("RightPunch", true);
      }
      // ガード
      if (inputManager.GetDownLeft1()
        && inputManager.GetDownRight1())
      {
        anim.SetBool("Guard", true);
      }
      // カウンター
      if (inputManager.GetDownRight1()
        || inputManager.GetDownLeft1())
      {
        if (boxerState.GetBoxerState2.IsName("Base Layer.Guard"))
        {
          anim.SetBool("Counter", true);
        }
      }
    }
  }
}
