
using UnityEngine;

public class inputManager : MonoBehaviour
{
  public static bool GetDownRight1P()
  {
    if (Input.GetKeyDown(KeyCode.JoystickButton0) ||
      Input.GetKeyDown(KeyCode.JoystickButton1) ||
      Input.GetKeyDown(KeyCode.D))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownLeft1P()
  {
    if (Input.GetKeyDown(KeyCode.JoystickButton2) ||
      Input.GetKeyDown(KeyCode.JoystickButton3) ||
      Input.GetKeyDown(KeyCode.A))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownStart1P()
  {
    if (Input.GetKeyDown(KeyCode.JoystickButton9) ||
        Input.GetKeyDown(KeyCode.S))
    {
      return true;
    }
    else { return false; }
  }

  public static bool GetDownLeft2P()
  {
    if (Input.GetKeyDown(KeyCode.Joystick1Button0) ||
      Input.GetKeyDown(KeyCode.Joystick1Button1) ||
      Input.GetKeyDown(KeyCode.J))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownRight2P()
  {
    if (Input.GetKeyDown(KeyCode.Joystick1Button2) ||
      Input.GetKeyDown(KeyCode.Joystick1Button3) ||
      Input.GetKeyDown(KeyCode.L))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownStart2P()
  {
    if (Input.GetKeyDown(KeyCode.Joystick1Button9) ||
      Input.GetKeyDown(KeyCode.K))
    {
      return true;
    }
    else { return false; }
  }

#if true

  private uint count = 0;

  void Update()
  {
    if (GetDownLeft1P()) { Debug.Log("GetDownLeft1P " + count++.ToString()); }
    if (GetDownRight1P()) { Debug.Log("GetDownRight1P " + count++.ToString()); }
    if (GetDownStart1P()) { Debug.Log("GetDownStart1P " + count++.ToString()); }
    if (GetDownLeft2P()) { Debug.Log("GetDownLeft2P " + count++.ToString()); }
    if (GetDownRight2P()) { Debug.Log("GetDownRight2P " + count++.ToString()); }
    if (GetDownStart2P()) { Debug.Log("GetDownStart2P " + count++.ToString()); }
  }

#endif

}
