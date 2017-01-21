using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LightManager : MonoBehaviour
{

    [SerializeField]
    private GameObject spown1PPoint;
    [SerializeField]
    private GameObject enterLights;
    [SerializeField]
    private GameObject battleLights;
    //[SerializeField]
    //private GameObject player1Obj, player2Obj;

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
    [CustomEditor(typeof(LightManager))]
    public class LightEditer : Editor
    {
        private bool _objectFolder = false;
        private bool _audioFolder = false;
        private bool _timeFolder = false;

        public override void OnInspectorGUI()
        {
            LightManager _editor = target as LightManager;

            if (_objectFolder = EditorGUILayout.Foldout(_objectFolder, "Objects"))
            {
                _editor.enterLights = EditorGUILayout.ObjectField("入場開始時ライト", _editor.enterLights, typeof(GameObject), true) as GameObject;
                _editor.battleLights = EditorGUILayout.ObjectField("バトル用ライト", _editor.battleLights, typeof(GameObject), true) as GameObject;
                //_editor.player1Obj = EditorGUILayout.ObjectField("1Pオブジェクト", _editor.player1Obj, typeof(GameObject), true) as GameObject;
                //_editor.player2Obj = EditorGUILayout.ObjectField("2Pオブジェクト", _editor.player2Obj, typeof(GameObject), true) as GameObject;
            }

            if (_audioFolder = EditorGUILayout.Foldout(_audioFolder, "Audios"))
            {
                _editor.entranceSE = EditorGUILayout.ObjectField("入場ジングル", _editor.entranceSE, typeof(AudioClip), false) as AudioClip;
                _editor.cheer = EditorGUILayout.ObjectField("歓声SE", _editor.cheer, typeof(AudioClip), false) as AudioClip;
            }

            if (_timeFolder = EditorGUILayout.Foldout(_timeFolder, "Timer"))
            {
                _editor.firstTime = EditorGUILayout.IntField("ライト無し時間", _editor.firstTime);
                _editor.secondTime = EditorGUILayout.IntField("入場演出ライト時間", _editor.secondTime);
                _editor.thirdTime = EditorGUILayout.IntField("バトルライト時間", _editor.thirdTime);
            }
        }
    }
#endif


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void firstLightEvent(ref int time)
    {
        time++;
    }

    void secondLightEvent(ref int time)
    {
        if (time == 0)
        {
            //登場ジングル
            audioSource.PlayOneShot(entranceSE);
            Instantiate(enterLights);
        }
        time++;
    }

    void thirdLightEvent(ref int time)
    {
        if (time == 0)
        {
            Destroy(GameObject.Find("tmpSpotLight(Clone)"));

            //歓声
            audioSource.PlayOneShot(cheer);

            Instantiate(battleLights);
            //Instantiate(player1Obj);
            //Instantiate(player2Obj);
        }
        time++;
    }

    void Update()
    {
        if (_firstCount < firstTime * 60)
        {
            firstLightEvent(ref _firstCount);
        }
        else if (_secondCount < secondTime * 60)
        {
            secondLightEvent(ref _secondCount);
        }
        else if (_thirdCount < thirdTime * 60)
        {
            thirdLightEvent(ref _thirdCount);
        }
        else
        {
            SceneManager.LoadScene("test");
        }
    }

}
