
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  Image[] hpBar;

  public static float hp1, hp2;

  [SerializeField]
  float punchDamage = 0.005f; // 0.005f
  [SerializeField]
  float punchDamageCounter = 0.05f; // 0.0075f

  void Awake()
  {
    hp1 = 1.0f; hp2 = 1.0f;
  }

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
      boxerState.LeftCounter2, boxerState.RightCounter2, 1);
    Counter(boxerState.Left2, boxerState.Right2,
      boxerState.LeftCounter1, boxerState.RightCounter1, 0);

    // 復帰
    if (hp1 == 0.0f)
    {
      Reborn(ref countManager.rebornCount1, 1, 0, 0.25f);
      Reborn(ref countManager.rebornCount1, 2, 0, 0.5f);
    }
    if (hp2 == 0.0f)
    {
      Reborn(ref countManager.rebornCount2, 1, 1, 0.25f);
      Reborn(ref countManager.rebornCount2, 2, 1, 0.5f);
    }
  }

  void Punch(bool state1, bool state2, int player)
  {
    if (state1 && state2)
    {
      hpBar[player].fillAmount -= punchDamage;
    }
  }

  void Counter(bool state1, bool state2,
    bool state3, bool state4, int player)
  {
    if (state1 || state2)
    {
      if (state3 || state4)
      {
        hpBar[player].fillAmount -= punchDamageCounter;
        Debug.Log("カウンターダメージ！");
      }
    }
  }

  void Reborn(ref int reCount, int limit, int player, float hp)
  {
    if (countManager.GetInputCount() == 10 && reCount == limit)
    {
      hpBar[player].fillAmount = hp;
      --reCount;
    }
  }
}
