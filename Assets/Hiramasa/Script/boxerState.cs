
using UnityEngine;

public class boxerState : MonoBehaviour
{
  private GameObject player1;
  private Animator player1animator;

  private GameObject player2;
  private Animator player2animator;

  private static AnimatorStateInfo player1State;
  private static AnimatorStateInfo player2State;

  public static AnimatorStateInfo getPlayer1State()
  {
    return player1State;
  }

  public static AnimatorStateInfo getPlayer2State()
  {
    return player2State;
  }

  void Start()
  {
    player1 = GameObject.Find("Boxer1");
    player1animator = player1.GetComponent<Animator>();

    player2 = GameObject.Find("Boxer2");
    player2animator = player2.GetComponent<Animator>();
  }

  void Update()
  {
    player1State = player1animator.GetCurrentAnimatorStateInfo(0);
    player2State = player2animator.GetCurrentAnimatorStateInfo(0);
  }
}
