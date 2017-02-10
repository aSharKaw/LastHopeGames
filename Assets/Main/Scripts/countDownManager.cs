
using UnityEngine;
using UnityEngine.UI;

public class countDownManager : MonoBehaviour
{
  Text countDown1, countDown2;

  static float time = 6;
  public static float GetTime() { return time; }

  float timeLeft = 0.0f;

  bool flag = true;

  void Awake()
  {
    time = 6;
    timeLeft = 0.0f;
    flag = true;
    countDown1 = GameObject.FindGameObjectWithTag("CountDown1").GetComponent<Text>();
    countDown2 = GameObject.FindGameObjectWithTag("CountDown2").GetComponent<Text>();
  }

  void Update()
  {
    timeLeft -= Time.deltaTime;

    if(timeLeft <= 0.0f)
    {
      timeLeft = 1.0f;
      time -= 1;
      countDown1.text = time.ToString();
      countDown2.text = countDown1.text;
    }

    if (GetTime() == 0.0f && flag)
    {
      countDown1.enabled = false;
      countDown2.enabled = false;
      soundManager.Instance.PlaySE(2);
      soundManager.Instance.PlayBGM(0);
      soundManager.Instance.PlaySE(0);
      flag = false;
    }
  }
}
