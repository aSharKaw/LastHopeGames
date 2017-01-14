using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EventManager : MonoBehaviour {

    [SerializeField]
    private GameObject spown1PPoint;
    [SerializeField]
    private GameObject defaultLight;
    [SerializeField]
    private GameObject enterLights;
    [SerializeField]
    private GameObject battleLights;
    [SerializeField]
    private GameObject player1Obj, player2Obj;

    //[SerializeField, Header("Audio")]
    //private AudioClip cheer;

    [SerializeField]
    private int firstTime;

    //[SerializeField]
    private int secondTime = 6 * 60;

    [SerializeField]
    private int thirdTime;

    //[SerializeField]
    //private int 

    /*
    inspector設定データ
    音源(Findでもry)
    各種状況以降時間
    */

#if UNITY_EDITOR//プランナー向けにInspector拡張
    [CustomEditor(typeof(EventManager))]
    public class EventEditer : Editor
    {
        private bool _objectFolder = false;
        private bool _audioFolder = false;

        public override void OnInspectorGUI()
        {
            EventManager _editor = target as EventManager;

            if(_objectFolder = EditorGUILayout.Foldout(_objectFolder, "Objects"))
            {
                _editor.defaultLight = EditorGUILayout.ObjectField("初期ライト", _editor.defaultLight, typeof(GameObject), true) as GameObject;
                _editor.enterLights = EditorGUILayout.ObjectField("入場開始時ライト", _editor.enterLights, typeof(GameObject), true) as GameObject;
                _editor.battleLights = EditorGUILayout.ObjectField("バトル用ライト", _editor.battleLights, typeof(GameObject), true) as GameObject;
                _editor.player1Obj = EditorGUILayout.ObjectField("1Pオブジェクト", _editor.player1Obj, typeof(GameObject), true) as GameObject;
                _editor.player2Obj = EditorGUILayout.ObjectField("2Pオブジェクト", _editor.player2Obj, typeof(GameObject), true) as GameObject;
            }

            //if(_audioFolder = EditorGUILayout.Foldout(_audioFolder, "Audio"))
            //{
            //    _editor.cheer = EditorGUILayout.ObjectField("歓声SE", _editor.cheer, typeof(AudioClip), true) as AudioClip;
            //}
        }
    }
#endif

    /*
    ロード入れるなら直で遷移、ロード無しならフェードインくらいはほしい。

    カメラは２つ。動作は同じ。（マルチウィンドウ用）

    明るい会場。ガヤガヤ。
    暗転（ライトを暗く）
    演出ライト開始。BGM開始
    エリア角にプレイヤー１。注視。歓声。ボタン入力でパンチできる。
    エリア別角にプレイヤー２。カメラ移動。歓声。ボタン入力でパンチできる。
    リングに2人を並べる。ライトをバトル用へ。リングを回るようなカメラワーク。
    シーン遷移→メイン
    */

    void StartScene(int timeLimit)//明るいとき
    {
        int _count = 0;

        Instantiate(defaultLight);

        while (_count < timeLimit)
        {
            _count++;

            //ガヤガヤ
        }
    }

    //int _count = 0;
    void PlayerEntrance(int timeLimit)//暗転して角にプレイヤー表示
    {
        //_count++;

        //if(_count > timeLimit)
        //{
        //   // SceneManager.LoadScene("");   
        //}
    }

    void BattleStart()//カメラ回転、リング状にプレイヤー表示、遷移
    {

    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < secondTime; i++)
        {

            if (i == secondTime / 4)
            {
                Instantiate(enterLights);
            }
            else if (i == (secondTime / 2))
            {
                Instantiate(battleLights);
                Instantiate(player1Obj);
                Instantiate(player2Obj);
            }
            else
            {
                //Debug.Log("シーン遷移");
                //SceneManager.LoadScene("");
            }
            //else if(_count < (timeLimit / 4 * 3))
            //{

            //}
            //else
            //{
            //    //
            //}

        }

    }
    int _count = 0;
    // Update is called once per frame
    void Update () {
        _count++;
        if(_count > secondTime)
        {
            Debug.Log("シーン遷移");
            SceneManager.LoadScene("test");

        }
    }
}
