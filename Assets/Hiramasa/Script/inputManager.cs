
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inputManager : MonoBehaviour
{
  public static bool GetDown1PLeft()
  {
    if (Input.GetButtonDown("1PTalconghaLeft") || Input.GetKeyDown(KeyCode.A))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDown1PRight()
  {
    if (Input.GetButtonDown("1PTalconghaRight") || Input.GetKeyDown(KeyCode.D))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDown1PStart()
  {
    if (Input.GetButtonDown("1PTalconghaStart") || Input.GetKeyDown(KeyCode.S))
    {
      return true;
    }
    else { return false; }
  }
}
