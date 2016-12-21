
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  private Image[] hpBar;

  void Update()
  {
    if (Input.GetButtonDown("TalconghaLeft"))
    {
      // 1P
      hpBar[0].fillAmount -= 0.025f;
    }
    if (Input.GetButtonDown("TalconghaRight"))
    {
      // 2P
      hpBar[1].fillAmount -= 0.025f;
    }
  }
}
