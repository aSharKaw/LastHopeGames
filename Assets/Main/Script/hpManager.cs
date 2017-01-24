
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
    if (inputManager.GetDownRight1())
    {
      // 1P
      //hpBar[0].fillAmount -= 0.025f;
    }
    if (boxerState.GetBoxerState1.IsName("Base Layer.RightPunch")
      && boxerState.GetBoxerState2.IsName("Base Layer.Idle"))
    {
      hpBar[1].fillAmount -= 0.001f; // 2P
    }
    if (boxerState.GetBoxerState1.IsName("Base Layer.LeftPunch")
      && boxerState.GetBoxerState2.IsName("Base Layer.Idle"))
    {
      hpBar[1].fillAmount -= 0.001f; // 2P
    }
    // 2P復帰
    if (boxerInput2.getCount2 == 100)
    {
      hpBar[1].fillAmount = 0.5f; // 2P
      Debug.Log("2P復帰");
    }

    hp1 = hpBar[0].fillAmount;
    hp2 = hpBar[1].fillAmount;

    Debug.Log(boxerInput2.getCount2);
  }
}
