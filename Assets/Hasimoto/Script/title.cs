using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour
{
    int pushcount = 0;
    float resettime = 0;
    float fadeouttime = 0;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            pushcount++;
            Debug.Log(pushcount + "回 押された");
            resettime = 0;
        }

        if (pushcount >= 3)
        {
            fadeout f = GetComponent<fadeout>();
            f.toFadeout();
            fadeouttime++;
        }

        if (fadeouttime > 120)
        {
            Debug.Log("シーン遷移しました");
            scenemanager s = GetComponent<scenemanager>();
            s.toNextScene();
        }

        if (resettime > 120 && fadeouttime == 0)
        {
            pushcount = 0;
            resettime = 0;
            Debug.Log("リセットされました");
        }

        if (pushcount >= 1)
        {
            resettime++;
        }

    }

}
