
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  private Image[] hpBar;

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
      // 2P
      hpBar[1].fillAmount -= 0.001f;
    }
  }
}
