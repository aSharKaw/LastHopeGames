
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class timeManager : MonoBehaviour
{
  [SerializeField]
  private Text time;

  private static ushort setTime = 60;
  private float timeLeft = 0.0f;

  public static ushort getTime() { return setTime; }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.A)) setTime = 10; // Debug
    timeLeft -= Time.deltaTime;

    if (timeLeft <= 0.0f && setTime != 0)
    {
      timeLeft = 1.0f;
      setTime -= 1;
      time.text = setTime.ToString();
    }
  }
}
