
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
  [SerializeField]
  private Image[] hpBar;

  void Update()
  {
    for (int i = 0; i < hpBar.Length; ++i)
    {
      hpBar[i].fillAmount -= 0.001f;
    }
  }
}
