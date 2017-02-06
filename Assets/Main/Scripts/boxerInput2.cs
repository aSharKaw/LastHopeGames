
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
    { anim.SetBool("Left", true); }
    else { anim.SetBool("Left", false); }

    // 右パンチ
    if (inputManager.GetDownRight2()
      && !inputManager.GetDownLeft2())
    { anim.SetBool("Right", true); }
    else { anim.SetBool("Right", false); }
  }
}
