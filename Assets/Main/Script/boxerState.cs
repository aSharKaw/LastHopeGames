
using UnityEngine;

public class boxerState : MonoBehaviour
{
  private GameObject boxer1;
  private GameObject boxer2;

  private Animator boxerAnim1;
  private Animator boxerAnim2;

  private static AnimatorStateInfo boxerState1;
  private static AnimatorStateInfo boxerState2;

  // Return
  public static AnimatorStateInfo GetBoxerState1() { return boxerState1; }
  public static AnimatorStateInfo GetBoxerState2() { return boxerState2; }

  void Start()
  {
    boxer1 = GameObject.Find("Boxer");
    boxerAnim1 = boxer1.GetComponent<Animator>();

    boxer2 = GameObject.Find("Boxer2");
    boxerAnim2 = boxer2.GetComponent<Animator>();
  }

  void Update()
  {
    boxerState1 = boxerAnim1.GetCurrentAnimatorStateInfo(0);
    boxerState2 = boxerAnim2.GetCurrentAnimatorStateInfo(0);
  }
}
