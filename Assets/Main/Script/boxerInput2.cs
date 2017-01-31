
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
    if (!pauseManager.getPause())
    {
      anim.SetBool("LeftPunch2", false);
      anim.SetBool("RightPunch2", false);
      anim.SetBool("Guard2", false);
      anim.SetBool("Counter2", false);
      anim.SetBool("Down2", false);
      anim.SetBool("Reborn2", false);

      // 左パンチ
      if (inputManager.GetDownLeft2()
        && !inputManager.GetDownRight2()
        && !boxerState.GetBoxerState1().IsName("Base Layer.Guard"))
      {
        anim.SetBool("LeftPunch2", true);
      }
      // 右パンチ
      if (inputManager.GetDownRight2()
        && !inputManager.GetDownLeft2()
        && !boxerState.GetBoxerState1().IsName("Base Layer.Guard"))
      {
        anim.SetBool("RightPunch2", true);
      }
      // ガード
      if (inputManager.GetDownLeft2()
        && inputManager.GetDownRight2())
      {
        anim.SetBool("Guard2", true);
      }
      // カウンター
      if (inputManager.GetDownRight2()
        || inputManager.GetDownLeft2())
      {
        if (boxerState.GetBoxerState1().IsName("Base Layer.Guard"))
        {
          anim.SetBool("Counter2", true);
        }
      }
      // ダウン
      if (hpManager.hp2 <= 0)
      {
        anim.SetBool("Down2", true);
      }
      // リターン
      if (countManager.Count == 10
        && rebornManager.Count != 0
        && !boxerState.GetBoxerState2().IsName("Base Layer.Reborn"))
      {
        anim.SetBool("Reborn2", true);
      }
    }
  }
}
