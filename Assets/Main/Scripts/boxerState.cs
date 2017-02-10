
using UnityEngine;

public class boxerState : MonoBehaviour
{
  [SerializeField]
  GameObject[] boxer;

  Animator anim1, anim2;

  static AnimatorStateInfo animState1, animState2;

  // 1Pまたは2Pが特定のモーション中かどうか判定できる
  public static bool Idle1, Idle2;
  public static bool Left1, Left2;
  public static bool Right1, Right2;
  public static bool LeftCounter1, LeftCounter2;
  public static bool RightCounter1, RightCounter2;
  public static bool Guard1, Guard2;
  public static bool Down1, Down2;
  public static bool Reborn1, Reborn2;
  public static bool Damage1, Damage2;

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
    LeftCounter1 = animState1.IsName("Base Layer.LeftCounter");
    LeftCounter2 = animState2.IsName("Base Layer.LeftCounter");
    RightCounter1 = animState1.IsName("Base Layer.RightCounter");
    RightCounter2 = animState2.IsName("Base Layer.RightCounter");
    Guard1 = animState1.IsName("Base Layer.Guard");
    Guard2 = animState2.IsName("Base Layer.Guard");
    Down1 = animState1.IsName("Base Layer.Down");
    Down2 = animState2.IsName("Base Layer.Down");
    Reborn1 = animState1.IsName("Base Layer.Reborn");
    Reborn2 = animState2.IsName("Base Layer.Reborn");
    Damage1 = animState1.IsName("Base Layer.Damage");
    Damage2 = animState2.IsName("Base Layer.Damage");
  }
}
