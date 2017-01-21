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

    [SerializeField]
    private AudioClip entranceSE;
    [SerializeField]
    private AudioClip cheer;
    
    private AudioSource audioSource;

    [SerializeField]
    private int firstTime = 2;
    [SerializeField]
    private int secondTime = 4;
    [SerializeField]
    private int thirdTime = 2;

    [System.NonSerialized]
    private int _firstCount = 0, _secondCount = 0, _thirdCount = 0;
    
#if UNITY_EDITOR//プランナー向けにInspector拡張
    [CustomEditor(typeof(EventManager))]
    public class EventEditer : Editor
    {
        private bool _objectFolder = false;
        private bool _audioFolder = false;
        private bool _timeFolder = false;


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

            if(_audioFolder = EditorGUILayout.Foldout(_audioFolder, "Audios"))
            {
                _editor.entranceSE = EditorGUILayout.ObjectField("入場ジングル", _editor.entranceSE, typeof(AudioClip), false) as AudioClip;
                _editor.cheer = EditorGUILayout.ObjectField("歓声SE", _editor.cheer, typeof(AudioClip), false)as AudioClip;
            }

            if(_timeFolder = EditorGUILayout.Foldout(_timeFolder, "Times"))
            {
                _editor.firstTime = EditorGUILayout.IntField("初期演出時間", _editor.firstTime);
                _editor.secondTime = EditorGUILayout.IntField("入場演出時間", _editor.secondTime);
                _editor.thirdTime = EditorGUILayout.IntField("選手注目時間", _editor.thirdTime);
            }
        }
    }
#endif

    /*
    カメラは２つ。動作は同じ。（マルチウィンドウ用）

    リングに2人を並べる。ライトをバトル用へ。リングを回るようなカメラワーク。
    シーン遷移→メイン
    */
    
    void Start ()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update ()
    {
        if(_firstCount < firstTime * 60)
        {
            if (_firstCount == 0)
            {
                //ガヤガヤ

            }

            _firstCount++;
        }
        else if(_secondCount < secondTime * 60)
        {
            if (_secondCount == 0)
            {
                //登場ジングル
                audioSource.PlayOneShot(entranceSE);

                Instantiate(enterLights);
            }

            _secondCount++;
        }
        else if(_thirdCount < thirdTime * 60)
        {
            
            if (_thirdCount == 0)
            {
      　        Destroy(GameObject.Find("tmpSpotLight(Clone)"));

                //歓声
                audioSource.PlayOneShot(cheer);

                Instantiate(battleLights);
                Instantiate(player1Obj);
                Instantiate(player2Obj);
            }

            _thirdCount++;
        }
        else
        {
            SceneManager.LoadScene("test");
        }
    }
}
