
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inputManager : MonoBehaviour
{
  void Update()
  {
    // こいつで入力が取れる
    if (Input.GetButtonDown("1PTalconghaLeft")) { }
    if (Input.GetButtonDown("1PTalconghaRight")) { }
    if (Input.GetButtonDown("1PTalconghaStart")) { }
  }
}
