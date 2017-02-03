using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EventManager : MonoBehaviour {
    
    //他スクリプトで使うからとりあえずpublicで
    [SerializeField]
    public int firstLightTime;
    [SerializeField]
    public int secondLightTime;
    [SerializeField]
    public int thirdLightTime;
    [SerializeField]
    public int firstCameraTime;
    [SerializeField]
    public int secondCameraTime;
    [SerializeField]
    public int thirdCameraTime;

    private int fullCount;
    private int count;


#if UNITY_EDITOR//プランナー向けにInspector拡張
    [CustomEditor(typeof(EventManager))]
    public class EventEditer : Editor
    {
        private bool _lightTimeFolder = false;
        private bool _cameraTimeFolder = false;

        public override void OnInspectorGUI()
        {
            EventManager _editor = target as EventManager;

            if(_lightTimeFolder = EditorGUILayout.Foldout(_lightTimeFolder, "LightTimer"))
            {
                _editor.firstLightTime = EditorGUILayout.IntField("ライト無し時間", _editor.firstLightTime);
                _editor.secondLightTime = EditorGUILayout.IntField("入場演出ライト時間", _editor.secondLightTime);
                _editor.thirdLightTime = EditorGUILayout.IntField("バトルライト時間", _editor.thirdLightTime);
            }

            if (_cameraTimeFolder = EditorGUILayout.Foldout(_cameraTimeFolder, "CameraTimer"))
            {
                _editor.firstCameraTime = EditorGUILayout.IntField("初期カメラ時間", _editor.firstCameraTime);
                _editor.secondCameraTime = EditorGUILayout.IntField("選手注目時間", _editor.secondCameraTime);
                _editor.thirdCameraTime = EditorGUILayout.IntField("バトル演出カメラ時間", _editor.thirdCameraTime);
            }
        }
    }
#endif

    void Start()
    {
        if(firstLightTime + secondLightTime + thirdLightTime > firstCameraTime + secondCameraTime + thirdCameraTime)
        {
            fullCount = firstLightTime + secondLightTime + thirdLightTime;
        }
        else
        {
            fullCount = firstCameraTime + secondCameraTime + thirdCameraTime;
        }
        Debug.Log("Start通った");
    }

    void Updata()
    {
        if (count > fullCount)
        {
            Debug.Log("終わったよ");
            SceneManager.LoadScene("main");
        }
        count++;
        Debug.Log(fullCount + " / " + count);
    }
}
