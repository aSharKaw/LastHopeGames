
using UnityEngine;

public class inputManager : MonoBehaviour
{
  // 1P Input
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

  // 2P Input 
  public static bool GetDown2PLeft()
  {
    if (Input.GetButtonDown("2PTalconghaLeft") || Input.GetKeyDown(KeyCode.J))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDown2PRight()
  {
    if (Input.GetButtonDown("2PTalconghaRight") || Input.GetKeyDown(KeyCode.L))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDown2PStart()
  {
    if (Input.GetButtonDown("2PTalconghaStart") || Input.GetKeyDown(KeyCode.K))
    {
      return true;
    }
    else { return false; }
  }
}
