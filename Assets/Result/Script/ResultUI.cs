using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{

    [SerializeField]
    private GameObject overObj;
    [SerializeField]
    private GameObject underObj;

    private Image overImage;
    private Image underImage;

    [SerializeField]
    private float _speed;

    // Use this for initialization
    void Awake()
    {
        overImage = overObj.GetComponent<Image>();
        underImage = underObj.GetComponent<Image>();

        //消しておく
        underImage.color = new Color(underImage.color.r,
            underImage.color.g,
            underImage.color.b,
            0);
    }

    // Update is called once per frame
    void Update()
    {
        //現在のα値を取得
        float toColor = underImage.color.a;
        //α値が0か1になったら増減値を反転
        if (toColor < 0 || toColor > 1)
        {
            _speed = _speed * -1;
        }

        //α値を弄り続ける
        underImage.color = new Color(underImage.color.r,
            underImage.color.g,
            underImage.color.b,
            toColor + _speed);
    }
}
