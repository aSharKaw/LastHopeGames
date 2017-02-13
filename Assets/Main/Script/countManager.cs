
using UnityEngine;

public class countManager : MonoBehaviour
{
    public static int Count = 0; // 復帰に必要な叩く回数

    private float timeLeft = 1.0f; // 後で直す

    void Update()
    {
        M(hpManager.hp1,
          inputManager.GetDownLeft1(),
          inputManager.GetDownRight1());

        M(hpManager.hp2,
          inputManager.GetDownLeft2(),
          inputManager.GetDownRight2());
        Debug.Log("count" + Count);
        if (Count >= 10)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log(Count);
            
            if (timeLeft <= 0.5f)
            {
                Count = 0;
                timeLeft = 1;
                Debug.Log("Countが初期化されました"); // 通ってる
            }
            
        }
    }

    void M(float hp, bool f1, bool f2)
    {
        if (hp == 0.0f)
        {
            if (f1 || f2) { Count++; }
        }
    }
}
