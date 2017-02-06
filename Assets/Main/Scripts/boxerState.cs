
using UnityEngine;

public class boxerState : MonoBehaviour
{
  [SerializeField]
  GameObject[] boxer;

  Animator anim1, anim2;

  static AnimatorStateInfo animState1, animState2;

  public static bool Idle1, Idle2;
  public static bool Left1, Left2;
  public static bool Right1, Right2;

  void Start()
  {
    anim1 = boxer[0].GetComponent<Animator>();
    anim2 = boxer[1].GetComponent<Animator>();
  }

  void Update()
  {
    animState1 = anim1.GetCurrentAnimatorStateInfo(0);
    animState2 = anim2.GetCurrentAnimatorStateInfo(0);

    Idle1 = animState1.IsName("Base Layer.Idle");
    Idle2 = animState2.IsName("Base Layer.Idle");
    Left1 = animState1.IsName("Base Layer.Left");
    Left2 = animState2.IsName("Base Layer.Left");
    Right1 = animState1.IsName("Base Layer.Right");
    Right2 = animState2.IsName("Base Layer.Right");
  }
}
