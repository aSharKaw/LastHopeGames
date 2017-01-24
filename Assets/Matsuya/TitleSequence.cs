using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSequence : MonoBehaviour
{
    //鳴らすオーディオソース
    private AudioSource _BGMsource;

    //フェードの付いているオブジェクト
    [SerializeField]
    private GameObject _FadeObj;
    //チームロゴオブジェクト
    [SerializeField]
    private GameObject _TeamLogoObj;
    //注意書きのイメージオブジェクト
    [SerializeField]
    private GameObject _WarningObj;
    //判定を取っているオブジェクト
    [SerializeField]
    private GameObject _JudgeObj;
    //待ってもらうイメージオブジェクト
    [SerializeField]
    private GameObject _StopObj;

    //フェードを指定
    private Fade _fade;
    //判定の指定
    private Beat _beat;

    //タイトルの流れを切り替える変数
    private int titleSwitch = 0;
    //時間で管理
    private int switchCount = 0;

    //ロゴ時間
    [SerializeField]
    private float teamlogoTime;
    //注意書き時間
    [SerializeField]
    private float warningTime;

    //回転速度
    [SerializeField]
    private float rotateSpeed = 0;

    //終了判定
    public bool title_end;

    //初期化
    void Awake()
    {
        //変数のリセット
        titleSwitch = 0;
        switchCount = 0;

        //フェード準備
        _fade = _FadeObj.GetComponent<Fade>();
        _beat = _JudgeObj.GetComponent<Beat>();

        //色などを初期化
        StartCoroutine(_fade.reset(0f, 0f, 0f, 1.0f));

        //オーディオを見つけてくる
        _BGMsource = gameObject.GetComponent<AudioSource>();
        //ループをonにしておく
        _BGMsource.loop = true;

        //判定を切っておく
        title_end = false;
    }

    //画面更新
    void Update()
    {
        //切り替えのカウントを足す
        switchCount++;
        //回転させる
        transform.Rotate(new Vector3(0, rotateSpeed, 0));

        //タイトルシーケンス
        switch (titleSwitch)
        {
            case 0:

                //チームロゴをつけておく
                _TeamLogoObj.SetActive(true);
                //注意書きを消す
                _WarningObj.SetActive(false);
                //判定を取っているオブジェクト
                _JudgeObj.SetActive(false);
                //止まってもらうイメージを消す
                _StopObj.SetActive(false);
                //音量を戻しておく
                _BGMsource.volume = 1;

                titleSwitch++;

                break;
            //チームロゴ表示
            case 1:

                //時間で進行
                if (switchCount >= 60 * teamlogoTime)
                {
                    Debug.Log("注意表示へ");
                    _TeamLogoObj.SetActive(false);
                    _WarningObj.SetActive(true);
                    titleSwitch++;
                    switchCount = 0;
                }
                break;
            //注意表示
            case 2:
                if (switchCount >= 60 * warningTime)
                {
                    Debug.Log("ロゴ表示へ");
                    _WarningObj.SetActive(false);
                    //曲を流し始める
                    _BGMsource.PlayOneShot(_BGMsource.clip);
                    titleSwitch++;
                    switchCount = 0;
                }
                break;
            //タイトルロゴ表示
            case 3:

                //フェードイン
                _fade.toFadein(0.02f);
                if (_fade.alpha <= 0)
                {
                    titleSwitch++;
                }

                break;
            case 4:

                _JudgeObj.SetActive(true);

                //終了したら次へ
                if (_beat.endbool) titleSwitch++;

                //終了していない状態で
                if (!_beat.endbool)
                {
                    //一分間放置でやり直し
                    if (switchCount >= 60 * 10)
                    {
                        //判定を消しておく
                        _JudgeObj.SetActive(false);

                        //フェ―ドアウト
                        _fade.toFadeout(0.02f);
                        if (_fade.alpha >= 1)
                        {
                            _BGMsource.volume -= 0.1f;
                            if(_BGMsource.volume <= 0)
                            {
                                _BGMsource.Stop();
                                titleSwitch = 0;
                                switchCount = 0;
                            }
                        }
                    }
                }
                break;
            case 5:
                //フェードの色変更
                _fade.reset(0, 0, 0, 0);
                titleSwitch++;
                switchCount = 0;
                break;
            case 6:
                //BGMを消しながらフェードアウト
                _fade.toFadeout(0.02f);
                _BGMsource.volume -= 0.1f;
                if (_BGMsource.volume <= 0) _BGMsource.Stop();

                //フェードが完了したら待たせる
                if (_fade.alpha >= 1)
                {
                    title_end = true;
                    if(switchCount >= 60 * 2)
                    {
                        _StopObj.SetActive(true);
                    }
                }
                break;
        }
    }
}
