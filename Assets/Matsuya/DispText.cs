using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispText : MonoBehaviour
{
    //フェードパネル
    [SerializeField]
    private GameObject fadeObj;
    //文字を取得
    private Text _text;

    //スポットライト1
    [SerializeField]
    private GameObject Light_1;
    //スポットライト2
    [SerializeField]
    private GameObject Light_2;

    //α値の増減値
    [SerializeField, Range(0, 0.1f)]
    private float _speed = 0.05f;

    //押されたカウント
    private int pushcount = 0;
    //リセットまでの時間
    private int resettime = 0;

    //初期化
    void Awake()
    {
        //テキスト取得
        _text = gameObject.GetComponent<Text>();
        Light_1.SetActive(false);
        Light_2.SetActive(false);
    }

    //毎フレーム更新
    void Update()
    {
        Debug.Log(resettime);
        //三回以下なら終了
        if (pushcount < 3)
        {
            //リセットまでの時間
            resettime++;
            if (resettime > 120)
            {
                pushcount = 0;
                Light_1.SetActive(false);
                Light_2.SetActive(false);
            }
            //押されたらコルーチン起動
            if (Input.anyKeyDown) StartCoroutine("Push");
        }
        else
        {
            fadeout f = fadeObj.GetComponent<fadeout>();
            f.toFadeout(0.02f);
            resettime = 0;
        }

        //現在のα値を取得
        float toColor = _text.color.a;
        //α値が0か1になったら増減値を反転
        if (toColor < 0 || toColor > 1)
        {
            _speed = _speed * -1;
        }
        //α値を弄り続ける
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, toColor + _speed);
    }

    //押された時の処理
    IEnumerator Push()
    {
        pushcount++;
        Debug.Log(pushcount + "回押された");
        resettime = 0;
        //ライトオン
        Light_1.SetActive(true);
        if(pushcount == 1) yield break;
        //ライトオン
        Light_2.SetActive(true);
        if (pushcount == 2) yield break;
    }
}
