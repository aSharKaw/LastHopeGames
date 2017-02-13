
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  private Image[] hpBar;

  public static float hp1 = 1.0f;
  public static float hp2 = 1.0f;

  private float punchDamage = 0.005f;

  void Update()
  {
    // 変数名が長い為、変数に保存
    hp1 = hpBar[0].fillAmount;
    hp2 = hpBar[1].fillAmount;

    // Display1のUI表示をDisplay2にも反映させる
    hpBar[2].fillAmount = hpBar[1].fillAmount;
    hpBar[3].fillAmount = hpBar[0].fillAmount;

    // 1Pが左パンチ
    if (boxerState.GetBoxerState1().IsName("Base Layer.LeftPunch")
      && boxerState.GetBoxerState2().IsName("Base Layer.Idle"))
    {
      hpBar[1].fillAmount -= punchDamage;
    }
    // 1Pが右パンチ
    if (boxerState.GetBoxerState1().IsName("Base Layer.RightPunch")
      && boxerState.GetBoxerState2().IsName("Base Layer.Idle"))
    {
      hpBar[1].fillAmount -= punchDamage;
    }
    // 2Pが左パンチ
    if (boxerState.GetBoxerState2().IsName("Base Layer.LeftPunch")
      && boxerState.GetBoxerState1().IsName("Base Layer.Idle"))
    {
      hpBar[0].fillAmount -= punchDamage;
    }
    // 2Pが右パンチ
    if (boxerState.GetBoxerState2().IsName("Base Layer.RightPunch")
      && boxerState.GetBoxerState1().IsName("Base Layer.Idle"))
    {
      hpBar[0].fillAmount -= punchDamage;
    }

    // 1Pがカウンター状態
    if (boxerState.GetBoxerState2().IsName("Base Layer.LeftPunch")
      || boxerState.GetBoxerState2().IsName("Base Layer.RightPunch"))
    {
      if (boxerState.GetBoxerState1().IsName("Base Layer.Counter"))
      {
        hpBar[0].fillAmount -= 0.003f;
      }
    }
    // 2Pがカウンター状態
    if (boxerState.GetBoxerState1().IsName("Base Layer.LeftPunch")
      || boxerState.GetBoxerState1().IsName("Base Layer.RightPunch"))
    {
      if (boxerState.GetBoxerState2().IsName("Base Layer.Counter"))
      {
        hpBar[1].fillAmount -= 0.003f;
      }
    }
    
    // 復帰
    if(hp1 == 0.0f)
    {
            Return(ref rebornManager.Count, 1, 0, 0.25f);

            Return(ref rebornManager.Count, 2, 0, 0.5f);
    }
    if(hp2 == 0.0f)
    {
            Return(ref rebornManager.Count2, 1, 1, 0.25f);

            Return(ref rebornManager.Count2, 2, 1, 0.5f);
    }

    Debug.Log(rebornManager.Count2);
  }

  // 復帰
  void Return(ref int returncount, int limit, int player, float hp)
  {
    if (countManager.Count == 10
      && returncount == limit)
    {
            Debug.Log("復帰チェック");
      hpBar[player].fillAmount = hp;
      //countManager.Count = 0;
      returncount--;
            Debug.Log("return" + returncount);
    }
  }
}
