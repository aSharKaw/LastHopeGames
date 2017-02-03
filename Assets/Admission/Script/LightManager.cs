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
    [SerializeField]
    private GameObject player1Obj, player2Obj;
    [SerializeField]
    private GameObject spotLight;

    [SerializeField]
    private AudioClip entranceSE;
    [SerializeField]
    private AudioClip cheer;

    private AudioSource audioSource;

    EventManager manager;

    //private Material material1P;
    //private Material material2P;

    private int firstTime;
    private int secondTime;
    private int thirdTime;

    //[System.NonSerialized]
    private int _firstCount = 0, _secondCount = 0, _thirdCount = 0;

    private Vector3 Spot1PPosition = new Vector3(-13, 8, -13);
    private Vector3 Spot2PPosition = new Vector3(13, 8, 13);

#if UNITY_EDITOR//プランナー向けにInspector拡張
    [CustomEditor(typeof(LightManager))]
    public class LightEditer : Editor
    {
        private bool _objectFolder = false;
        private bool _audioFolder = false;

        public override void OnInspectorGUI()
        {
            LightManager _editor = target as LightManager;

            if (_objectFolder = EditorGUILayout.Foldout(_objectFolder, "Objects"))
            {
                _editor.enterLights = EditorGUILayout.ObjectField("入場開始時ライト", _editor.enterLights, typeof(GameObject), true) as GameObject;
                _editor.battleLights = EditorGUILayout.ObjectField("バトル用ライト", _editor.battleLights, typeof(GameObject), true) as GameObject;
                _editor.player1Obj = EditorGUILayout.ObjectField("1Pオブジェクト", _editor.player1Obj, typeof(GameObject), true) as GameObject;
                _editor.player2Obj = EditorGUILayout.ObjectField("2Pオブジェクト", _editor.player2Obj, typeof(GameObject), true) as GameObject;
                _editor.spotLight = EditorGUILayout.ObjectField("スポットライト", _editor.spotLight, typeof(GameObject), true) as GameObject;
            }

            if (_audioFolder = EditorGUILayout.Foldout(_audioFolder, "Audios"))
            {
                _editor.entranceSE = EditorGUILayout.ObjectField("入場ジングル", _editor.entranceSE, typeof(AudioClip), false) as AudioClip;
                _editor.cheer = EditorGUILayout.ObjectField("歓声SE", _editor.cheer, typeof(AudioClip), false) as AudioClip;
            }
        }
    }
#endif


    void Start()
    {
        manager = GetComponent<EventManager>();
        audioSource = gameObject.GetComponent<AudioSource>();

        firstTime = manager.firstLightTime;
        secondTime = manager.secondLightTime;
        thirdTime = manager.thirdLightTime;
    }

    public void firstLightEvent()
    {
    }

    public void secondLightEvent()
    {
        if (_secondCount == 0)
        {
            //登場ジングル
            audioSource.PlayOneShot(entranceSE);
            Instantiate(enterLights);
        }
    }

    public void thirdLightEvent()
    {
        if (_thirdCount == 0)
        {
            Destroy(GameObject.Find("tmpSpotLight(Clone)"));

            //歓声
            audioSource.PlayOneShot(cheer);


            Instantiate(spotLight, Spot1PPosition, Quaternion.Euler(90, 0, 0));
            Instantiate(spotLight, Spot2PPosition, Quaternion.Euler(90, 0, 0));
            Instantiate(battleLights);
            Instantiate(player1Obj);
            Instantiate(player2Obj);
        }
    }

    void Update()
    {
        if (_firstCount < firstTime * 60)
        {
            firstLightEvent();
            _firstCount++;
        }
        else if (_secondCount < secondTime * 60)
        {
            secondLightEvent();
            _secondCount++;
        }
        else if (_thirdCount < thirdTime * 60)
        {
            thirdLightEvent();
            _thirdCount++;
        }
        //else if(_thirdCount >= thirdTime * 60)
        //{
        //    SceneManager.LoadScene("main");
        //}

    }

}
