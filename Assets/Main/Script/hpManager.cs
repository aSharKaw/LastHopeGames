
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  private Image[] hpBar;

  public static float hp1;
  public static float hp2;

  private float punchDamage = 0.005f;

  void Awake()
  {
    hp1 = hpBar[0].fillAmount;
    hp2 = hpBar[1].fillAmount;
  }

  void Update()
  {
    hp1 = hpBar[0].fillAmount;
    hp2 = hpBar[1].fillAmount;

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
    
    if(hp1 == 0.0f)
    {
      Return(ref rebornManager.Count, 2, 0, 0.5f);
      Return(ref rebornManager.Count, 1, 0, 0.25f);
    }
    if(hp2 == 0.0f)
    {
      Return(ref rebornManager.Count2, 2, 1, 0.5f);
      Return(ref rebornManager.Count2, 1, 1, 0.25f);
    }
  }

  void Return(ref int returncount, int limit, int player, float hp)
  {
    if (countManager.Count == 10
      && returncount == limit)
    {
      hpBar[player].fillAmount = hp;
      countManager.Count = 0;
      returncount--;
    }
  }
}
