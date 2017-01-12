using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EventManager : MonoBehaviour {

    private GameObject defaultLight;
    private GameObject enterLights;
    private GameObject battleLights;
    private GameObject player1Obj, player2Obj;

    [SerializeField, Header("Audio")]
    private AudioClip Call;

    /*
    inspector設定データ
    音源(Findでもry)
    各種状況以降時間
    */

#if UNITY_EDITOR//プランナー向けにInspector拡張
    [CustomEditor(typeof(EventManager))]
    public class EventEditer : Editor
    {
        bool folder = false;

        public override void OnInspectorGUI()
        {
            EventManager editor = target as EventManager;

            if(folder = EditorGUILayout.Foldout(folder, "Objects"))
            {
                editor.defaultLight = EditorGUILayout.ObjectField("初期ライト", editor.defaultLight, typeof(GameObject), true) as GameObject;
                editor.enterLights = EditorGUILayout.ObjectField("入場開始時ライト", editor.enterLights, typeof(GameObject), true) as GameObject;
                editor.battleLights = EditorGUILayout.ObjectField("バトル用ライト", editor.battleLights, typeof(GameObject), true) as GameObject;
                editor.player1Obj = EditorGUILayout.ObjectField("1Pオブジェクト", editor.player1Obj, typeof(GameObject), true) as GameObject;
                editor.player2Obj = EditorGUILayout.ObjectField("2Pオブジェクト", editor.player2Obj, typeof(GameObject), true) as GameObject;
            }
        }
    }
#endif



    /*
    ロード？入れるなら、タイトルシーンを弄ること。ここじゃない。
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

    void StartScene()
    {

    }

    void PlayerEntrance()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
