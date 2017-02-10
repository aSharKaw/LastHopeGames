
using UnityEngine;

public class boxerInput2 : MonoBehaviour
{
  private Animator anim;

  private bool flag = true;

  void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    // カウントダウン中なら実行しない
    if (countDownManager.GetTime() <= -0.0f)
    {
      // ポーズ中なら実行しない
      if (!pauseManager.getPause())
      {
        // 2Pがダウンしてるときは全て無効化
        if (!boxerState.Down1)
        {
          // リボーンのときも無効化
          if (!boxerState.Reborn1)
          {
            // 左パンチ
            if (inputManager.GetDownLeft2()
              && !inputManager.GetDownRight2()
              && !boxerState.Guard1)
            {
              if (!boxerState.Left2
                && !boxerState.Down2
                && !boxerState.LeftCounter2
                && !boxerState.Damage2)
              {
                anim.SetBool("Left", true);
                soundManager.Instance.PlaySE(5);
              }
            }
            else { anim.SetBool("Left", false); }

            // 右パンチ
            if (inputManager.GetDownRight2()
              && !inputManager.GetDownLeft2()
              && !boxerState.Guard1)
            {
              if (!boxerState.Right2
                && !boxerState.Down2
                && !boxerState.RightCounter2
                && !boxerState.Damage2)
              {
                anim.SetBool("Right", true);
                soundManager.Instance.PlaySE(4);
              }
            }
            else { anim.SetBool("Right", false); }

            // ガード
            if (inputManager.GetDownLeft2()
              && inputManager.GetDownRight2())
            {
              anim.SetBool("Guard", true);
            }
            else { anim.SetBool("Guard", false); }

            // 左カウンター
            if (inputManager.GetDownLeft2())
            {
              if (boxerState.Guard1)
              {
                anim.SetBool("LeftCounter", true);
              }
            }
            else { anim.SetBool("LeftCounter", false); }

            // 右カウンター
            if (inputManager.GetDownRight2())
            {
              if (boxerState.Guard1)
              {
                anim.SetBool("RightCounter", true);
              }
            }
            else { anim.SetBool("RightCounter", false); }

            // ダウン
            if (hpManager.hp2 <= 0.0f)
            {
              if (flag)
              {
                anim.SetBool("Down", true);
                soundManager.Instance.PlaySE(8);
                countManager.downCount2++;
                flag = false;
              }
            }
            else { anim.SetBool("Down", false); flag = true; }

            // ダメージ
            if (boxerState.Left1 || boxerState.Right1)
            { anim.SetBool("Damage", true); }
            else { anim.SetBool("Damage", false); }
          }
        }
      }
    }
  }
}