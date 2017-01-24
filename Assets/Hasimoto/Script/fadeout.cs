using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadeout : MonoBehaviour
{
    public float alpha = 0;
    private float red, green, blue;

    public void toFadeout(float speed)
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

        GetComponent<Image>().color = new Color(red, green, blue, alpha);
        alpha += speed;
    }

    public void reset()
    {
        alpha = 0;
    }
}
