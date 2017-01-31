
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
  [SerializeField]
  private Text time;

  private static int setTime = 60;
  private float timeLeft = 0.0f;

  public static int getTime() { return setTime; }

  void Update()
  {
    // ポーズ中じゃなければ実行
    if (!pauseManager.getPause())
    {
      timeLeft -= Time.deltaTime;

      if (timeLeft <= 0.0f && setTime != 0)
      {
        timeLeft = 1.0f;
        setTime -= 1;
        time.text = setTime.ToString();
      }
    }

#if false

    if (Input.GetKeyDown(KeyCode.T)) setTime = 10;

#endif

  }
}
