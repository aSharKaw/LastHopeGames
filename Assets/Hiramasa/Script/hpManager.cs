
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  private Image[] hpBar;

  void Update()
  {
    if (inputManager.GetDownRight1P())
    {
      // 1P
      // hpBar[0].fillAmount -= 0.025f;
    }
    if (boxerState.getPlayer1State().IsName("Base Layer.RightPunch")
      && boxerState.getPlayer2State().IsName("Base Layer.Idle"))
    {
      // 2P
      hpBar[1].fillAmount -= 0.005f;
    }
  }
}
