
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  Image[] hpBar;

  public static float hp1, hp2;

  [SerializeField]
  float punchDamage = 0.005f;
  [SerializeField]
  float punchDamageCounter = 0.0075f;

  void Update()
  {
    // 変数名が長い為、変数に保存
    hp1 = hpBar[0].fillAmount;
    hp2 = hpBar[1].fillAmount;

    // Display1のUI表示をDisplay2にも反映させる
    hpBar[2].fillAmount = hpBar[1].fillAmount;
    hpBar[3].fillAmount = hpBar[0].fillAmount;

    Punch(boxerState.Left1, boxerState.Idle2, 1);
    Punch(boxerState.Left2, boxerState.Idle1, 0);
    Punch(boxerState.Right1, boxerState.Idle2, 1);
    Punch(boxerState.Right2, boxerState.Idle1, 0);

    Counter(boxerState.Left1, boxerState.Right1,
      boxerState.CounterLeft2, boxerState.CounterRight2, 1);
    Counter(boxerState.Left2, boxerState.Right2,
      boxerState.CounterLeft1, boxerState.CounterRight1, 0);
  }

  void Punch(bool state1, bool state2, int player)
  {
    if (state1 && state2)
    {
      hpBar[player].fillAmount -= punchDamage;
    }
  }

  void Counter(bool state1, bool state2,
    bool state3, bool state4 ,int player)
  {
    if (state1 || state2)
    {
      if (state3 || state4)
      {
        hpBar[player].fillAmount -= punchDamageCounter;
      }
    }
  }
}
