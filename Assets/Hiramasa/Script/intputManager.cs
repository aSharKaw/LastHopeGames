
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class intputManager : MonoBehaviour
{
  void Update()
  {
    // こいつで入力が取れる
    if (Input.GetButtonDown("TalconghaLeft")) { }
    if (Input.GetButtonDown("TalconghaRight")) { }
    if (Input.GetButtonDown("TalconghaStart")) { }
  }
}
