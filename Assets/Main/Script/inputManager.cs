
using UnityEngine;

public class inputManager : MonoBehaviour
{
  public static bool GetDownRight1()
  {
    if (Input.GetKeyDown(KeyCode.JoystickButton0) ||
      Input.GetKeyDown(KeyCode.JoystickButton1) ||
      Input.GetKeyDown(KeyCode.D))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownLeft1()
  {
    if (Input.GetKeyDown(KeyCode.JoystickButton2) ||
      Input.GetKeyDown(KeyCode.JoystickButton3) ||
      Input.GetKeyDown(KeyCode.A))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownStart1()
  {
    if (Input.GetKeyDown(KeyCode.JoystickButton9) ||
        Input.GetKeyDown(KeyCode.S))
    {
      return true;
    }
    else { return false; }
  }

  public static bool GetDownLeft2()
  {
    if (Input.GetKeyDown(KeyCode.Joystick1Button0) ||
      Input.GetKeyDown(KeyCode.Joystick1Button1) ||
      Input.GetKeyDown(KeyCode.J))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownRight2()
  {
    if (Input.GetKeyDown(KeyCode.Joystick1Button2) ||
      Input.GetKeyDown(KeyCode.Joystick1Button3) ||
      Input.GetKeyDown(KeyCode.L))
    {
      return true;
    }
    else { return false; }
  }
  public static bool GetDownStart2()
  {
    if (Input.GetKeyDown(KeyCode.Joystick1Button9) ||
      Input.GetKeyDown(KeyCode.K))
    {
      return true;
    }
    else { return false; }
  }

#if true

  private int count = 0;

  void Update()
  {
    if (GetDownLeft1()) { Debug.Log($"GetLeft1 + {++count}"); }
    if (GetDownRight1()) { Debug.Log($"GetRight1 + {++count}"); }
    if (GetDownStart1()) { Debug.Log($"GetStart1 + {++count}"); }
    if (GetDownLeft2()) { Debug.Log($"GetLeft2 + {++count}");}
    if (GetDownRight2()) { Debug.Log($"GetRight2 + {++count}"); }
    if (GetDownStart2()) { Debug.Log($"GetStart2 + {++count}"); }
  }

#endif

}
