using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//プレイ回数確認用
public class PlayCount : MonoBehaviour {


    private int playCount;
    [SerializeField]
    private Text countUI;

	void Start () {
        	
	}

    void GetPlayCount()
    {

    }

    void Update () {
        playCount = PlayerPrefs.GetInt("PlayCount");
        countUI.text = "PlayCount" + playCount.ToString();
    }
}
