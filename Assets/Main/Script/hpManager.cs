
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
    // 1Pが右パンチ
    if (boxerState.GetBoxerState1.IsName("Base Layer.RightPunch")
      && boxerState.GetBoxerState2.IsName("Base Layer.Idle"))
    {
      hpBar[1].fillAmount -= 0.001f; // 2P
    }
    // 1Pが左パンチ
    if (boxerState.GetBoxerState1.IsName("Base Layer.LeftPunch")
      && boxerState.GetBoxerState2.IsName("Base Layer.Idle"))
    {
      hpBar[1].fillAmount -= 0.001f; // 2P
    }
    // 2Pがカウンター状態
    if (boxerState.GetBoxerState1.IsName("Base Layer.LeftPunch")
      || boxerState.GetBoxerState1.IsName("Base Layer.RightPunch"))
    {
      if (boxerState.GetBoxerState2.IsName("Base Layer.Counter"))
      {
        hpBar[1].fillAmount -= 0.003f; // 2P
      }
    }
    // 2Pが復帰
    if (boxerInput2.getCount2 == 100)
    {
      hpBar[1].fillAmount = 0.5f; // 2P
      Debug.Log("2P復帰");
    }

    hp1 = hpBar[0].fillAmount;
    hp2 = hpBar[1].fillAmount;

    //Debug.Log(boxerInput2.getCount2);
  }
}
