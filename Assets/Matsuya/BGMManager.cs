using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{

    private AudioSource _source;
    //private AudioClip[] _clips;
    [SerializeField]
    private AudioClip _clip;

    // Use this for initialization
    void Awake()
    {
        //オーディオを見つけてくる
        _source = gameObject.GetComponent<AudioSource>();
        //再生
        _source.PlayOneShot(_clip);
        //ループをonにしておく
        _source.loop = true;
    }

    //IEnumerator SelectBGM()
    //{
    //    //シーン番号からBGMを選択
    //    _source.clip = _clips[SceneManager.sceneCount];
    //    yield break;
    //}
}
