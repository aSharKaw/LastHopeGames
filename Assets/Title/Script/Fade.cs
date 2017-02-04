using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    //α値
    public float alpha = 0;
    private float red, green, blue;

    //開始時に色指定
    public IEnumerator reset(float _red, float _green, float _blue, float _alpha)
    {
        //引数を代入
        red = _red;
        green = _green;
        blue = _blue;
        alpha = _alpha;

        //色を代入
        GetComponent<Image>().color =
            new Color(red, green, blue, alpha);
        yield break;
    }

    //フェードイン
    public void toFadein(float speed)
    {
        //色を当てはめる
        GetComponent<Image>().color =
            new Color(red, green, blue, alpha);
        //フェードインする
        alpha -= speed;
    }

    //フェードアウト
    public void toFadeout(float speed)
    {
        //色を当てはめる
        GetComponent<Image>().color =
            new Color(red, green, blue, alpha);
        //フェードアウトする
        alpha += speed;
    }
}
