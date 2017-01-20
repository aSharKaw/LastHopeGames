using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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


    //音の出るとこ
    private AudioSource _audioSource;
    //サウンドクリップ
    [SerializeField]
    private AudioClip[] _clip;

    //初期化
    void Awake()
    {
        //テキスト取得
        _text = gameObject.GetComponent<Text>();
        Light_1.SetActive(false);
        Light_2.SetActive(false);

        //ついているソースを引っ張る
        _audioSource = gameObject.GetComponent<AudioSource>();
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
            if (Input.anyKeyDown)
            {
                StartCoroutine("Push");
            }
        }
        else
        {
            //フェードアウトを起動
            fadeout f = fadeObj.GetComponent<fadeout>();
            f.toFadeout(0.02f);

            //フェードアウト完了でシーン遷移
            if(f.alpha >= 1.0f)
            {
//               SceneManager.LoadScene("Admisson");
            }
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
        _audioSource.clip = _clip[pushcount-1];
        _audioSource.Play();

        //放置対策をりせっと
        resettime = 0;
        //ライトオン
        Light_1.SetActive(true);

        if (pushcount == 1) yield break;
        //ライトオン
        Light_2.SetActive(true);
        if (pushcount == 2) yield break;
    }
}
