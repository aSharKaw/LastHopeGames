
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  private Image[] hpBar;

  public static float hp1;
  public static float hp2;

  void Awake()
  {
    hp1 = hpBar[0].fillAmount;
    hp2 = hpBar[1].fillAmount;
  }

  void Update()
  {
    // 1Pが左パンチ
    if (boxerState.GetBoxerState1().IsName("Base Layer.LeftPunch")
      && boxerState.GetBoxerState2().IsName("Base Layer.Idle"))
    {
      hpBar[1].fillAmount -= 0.005f; // 2P 0.001f
    }
    // 1Pが右パンチ
    if (boxerState.GetBoxerState1().IsName("Base Layer.RightPunch")
      && boxerState.GetBoxerState2().IsName("Base Layer.Idle"))
    {
      hpBar[1].fillAmount -= 0.001f; // 2P
    }
    // 2Pがカウンター状態
    if (boxerState.GetBoxerState1().IsName("Base Layer.LeftPunch")
      || boxerState.GetBoxerState1().IsName("Base Layer.RightPunch"))
    {
      if (boxerState.GetBoxerState2().IsName("Base Layer.Counter"))
      {
        hpBar[1].fillAmount -= 0.003f; // 2P
      }
    }
    
    // 復帰処理
    Return(rebornManager.Count, 2, 0, 0.5f);
    Return(rebornManager.Count, 1, 0, 0.25f);

    Return(rebornManager.Count, 2, 1, 0.5f);
    Return(rebornManager.Count, 1, 1, 0.25f);

    hp1 = hpBar[0].fillAmount;
    hp2 = hpBar[1].fillAmount;
  }

  void Return(int returncount, int limit, int player, float hp)
  {
    if (countManager.Count == 10
      && returncount == limit)
    {
      hpBar[player].fillAmount = hp;
      countManager.Count = 0;
      rebornManager.Count--;
    }
  }
}
