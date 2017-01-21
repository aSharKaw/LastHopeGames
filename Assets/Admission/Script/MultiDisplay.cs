using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDisplay : MonoBehaviour {

    void Start()
    {
        int maxDisplayCount = 2;
        for (int i = 0; i < maxDisplayCount && i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}