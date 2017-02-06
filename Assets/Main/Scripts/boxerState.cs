
using UnityEngine;

public class boxerState : MonoBehaviour
{
  [SerializeField]
  private GameObject[] boxer;

  private Animator anim1, anim2;
  private static AnimatorStateInfo animState1, animState2;

  public static AnimatorStateInfo GetAnimState1() { return animState1; }
  public static AnimatorStateInfo GetAnimState2() { return animState2; }

  void Start()
  {
    anim1 = boxer[0].GetComponent<Animator>();
    anim2 = boxer[1].GetComponent<Animator>();
  }

  void Update()
  {
    animState1 = anim1.GetCurrentAnimatorStateInfo(0);
    animState2 = anim2.GetCurrentAnimatorStateInfo(0);
  }
}
