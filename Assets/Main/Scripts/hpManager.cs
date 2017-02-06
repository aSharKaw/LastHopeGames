
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  private Image[] hpBar;

  [SerializeField]
  private float punchDamage = 0.005f;
  [SerializeField]
  private float punchDamageCounter = 0.0075f;

  private static float hp1, hp2;
  public static float getHP1() { return hp1; }
  public static float getHP2() { return hp2; }

  void Update()
  {
    // 変数名が長い為、変数に保存
    hp1 = hpBar[0].fillAmount;
    hp2 = hpBar[1].fillAmount;

    // Display1のUI表示をDisplay2にも反映させる
    hpBar[2].fillAmount = hpBar[1].fillAmount;
    hpBar[3].fillAmount = hpBar[0].fillAmount;
  }
}
