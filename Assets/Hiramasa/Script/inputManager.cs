
using UnityEngine;

public class inputManager : MonoBehaviour
{
  public static bool GetDownRight1P()
  {
    if (Input.GetKey(KeyCode.JoystickButton0) ||
      Input.GetKey(KeyCode.JoystickButton1) ||
      Input.GetKeyDown(KeyCode.A))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownLeft1P()
  {
    if (Input.GetKey(KeyCode.JoystickButton2) ||
      Input.GetKey(KeyCode.JoystickButton3) ||
      Input.GetKeyDown(KeyCode.D))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownStart1P()
  {
    if (Input.GetKey(KeyCode.JoystickButton9) ||
      Input.GetKeyDown(KeyCode.S))
    {
      return true;
    }
    else { return false; }
  }

  public static bool GetDownLeft2P()
  {
    if (Input.GetKey(KeyCode.Joystick1Button0) ||
      Input.GetKey(KeyCode.Joystick1Button1) ||
      Input.GetKeyDown(KeyCode.J))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownRight2P()
  {
    if (Input.GetKey(KeyCode.Joystick1Button2) ||
      Input.GetKey(KeyCode.Joystick1Button3) ||
      Input.GetKeyDown(KeyCode.L))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownStart2P()
  {
    if (Input.GetKey(KeyCode.Joystick1Button9) ||
      Input.GetKeyDown(KeyCode.K))
    {
      return true;
    }
    else { return false; }
  }
}
