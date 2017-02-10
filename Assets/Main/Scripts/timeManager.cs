
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
  Text timeBlack1, timeBlack2, timeRed1, timeRed2;

  static float time = 60.0f;
  public static float GetTime() { return time; }

  int minute = 2;

  float timeLeft = 0.0f;

  static bool flag = false;
  public static bool GetCountEnd() { return flag; }

  void Start()
  {
    timeBlack1 = GameObject.Find("Time_Black1").GetComponent<Text>();
    timeBlack2 = GameObject.Find("Time_Black2").GetComponent<Text>();
    timeRed1 = GameObject.Find("Time_Red1").GetComponent<Text>();
    timeRed2 = GameObject.Find("Time_Red2").GetComponent<Text>();

    time = 60.0f; timeLeft = 0.0f; minute = 2; flag = false;
  }
  void Update()
  {
    if (time <= -1 && minute == 0)
    {
      flag = true;
      timeRed1.text = timeRed2.text
        = timeBlack1.text = timeBlack2.text = "0:00";

      Debug.Log("カウントは終了した");
    }

    if (!pauseManager.getPause())
    {
      if (countDownManager.GetTime() <= 0.0f && !flag)
      {
        if (countManager.downCount1 != 3)
        {
          if (countManager.downCount2 != 3)
          {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0.0f && time != -1)
            {
              timeLeft = 1.0f;
              time -= 1;

              if (time == -1 && minute != 0) { minute--; time = 60; }

              if (time <= 9 && time >= 0)
              {
                timeRed1.text = minute.ToString() + ":0" + time.ToString();
              }
              else
              {
                timeRed1.text = minute.ToString() + ":" + time.ToString();
              }

              timeRed2.text = timeBlack1.text = timeBlack2.text = timeRed1.text;
            }
          }
        }
      }
    }
  }
}
