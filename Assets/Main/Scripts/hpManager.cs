
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

    // 1Pが左パンチ
    if (boxerState.Left1 && boxerState.Idle2)
    {
      hpBar[1].fillAmount -= punchDamage;
    }
  }
}
