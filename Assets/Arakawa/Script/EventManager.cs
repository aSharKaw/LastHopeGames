using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EventManager : MonoBehaviour {
    
    //他スクリプトで使うからpublicで
    [SerializeField]
    public int firstLightTime = 2;
    [SerializeField]
    public int secondLightTime = 8;
    [SerializeField]
    public int thirdLightTime = 8;
    [SerializeField]
    public int firstCameraTime = 6;
    [SerializeField]
    public int secondCameraTime = 3;
    [SerializeField]
    public int thirdCameraTime = 3;

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
        fullCount = firstLightTime + secondLightTime + thirdLightTime + firstCameraTime + secondCameraTime + thirdCameraTime;
    }

    void Updata()
    {
        if(count > fullCount)
        {
            SceneManager.LoadScene("test");
        }
        count++;
    }
}
