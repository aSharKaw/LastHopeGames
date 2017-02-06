
using UnityEngine;

public class boxerInput1 : MonoBehaviour
{
  private Animator anim;

  void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    // 左パンチ
    if (inputManager.GetDownLeft1()
      && !inputManager.GetDownRight1())
    { anim.SetBool("Left", true); }
    else { anim.SetBool("Left", false); }

    // 右パンチ
    if (inputManager.GetDownRight1()
      && !inputManager.GetDownLeft1())
    { anim.SetBool("Right", true); }
    else { anim.SetBool("Right", false); }
  }
}
