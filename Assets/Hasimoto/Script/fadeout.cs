using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadeout : MonoBehaviour
{
    float alpha = 0;
    float red, green, blue;

    public void toFadeout(float speed)
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

        GetComponent<Image>().color = new Color(red, green, blue, alpha);
        alpha += speed;
    }
}
