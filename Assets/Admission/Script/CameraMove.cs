using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CameraMove : MonoBehaviour {

    [SerializeField]
    private GameObject Camera1P;
    [SerializeField]
    private GameObject Camera2P;

    private int count = 0;
    
    private int firstTime, secondTime, thirdTime;

    //初期カメラ位置
    private Vector3 firstPosition = new Vector3(14, 17, -14);
    private Vector3 firstRotation = new Vector3(30, -48, 0);

    //選手登場位置
    private Vector3 second1PPosition = new Vector3(-6, 4, -10);
    private Vector3 second1PRotation = new Vector3(20, -100, 0);
    private Vector3 second2PPosition = new Vector3(10, 4, 6);
    private Vector3 second2PRotation = new Vector3(20, 15, 0);

    //バトル演出用カメラ位置
    private Vector3 third1PPosition = new Vector3(0, 12, 0);
    private Vector3 third1PRotation = new Vector3(90, 0, 0);
    private Vector3 third2PPosition = new Vector3(0, 12, 0);
    private Vector3 third2PRotation = new Vector3(90, 180, 0);

    //バトルカメラ位置
    private Vector3 finish1PPosition = new Vector3(0, 3.316f, -0.508f);
    private Vector3 finish1PRotation = new Vector3(0, 0, 0);
    private Vector3 finish2PPosition = new Vector3(0, 3.3f, 0.5f);
    private Vector3 finish2PRotation = new Vector3(0, 180, 0);

    //バトル開始演出用
    private float move1PPos;
    private Vector3 move1PRot = Vector3.zero;
    private float move2PPos;
    private Vector3 move2PRot = Vector3.zero;

    EventManager EM;

#if UNITY_EDITOR
    [CustomEditor(typeof(CameraMove))]
    public class CameraEditer : Editor
    {
        private bool _objectFolder = false;
        
        public override void OnInspectorGUI()
        {
            CameraMove _editor = target as CameraMove;

            if (_objectFolder = EditorGUILayout.Foldout(_objectFolder, "Objects"))
            {
                _editor.Camera1P = EditorGUILayout.ObjectField("1Pカメラ", _editor.Camera1P, typeof(GameObject), true) as GameObject;
                _editor.Camera2P = EditorGUILayout.ObjectField("2Pカメラ", _editor.Camera2P, typeof(GameObject), true) as GameObject;
            }
            
        }
    }
#endif

    void Start ()
    {
        EM = GetComponent<EventManager>();

        firstTime = EM.firstCameraTime;
        secondTime = EM.secondCameraTime;
        thirdTime = EM.thirdCameraTime;

        move1PPos = Vector3.Distance(third1PPosition, finish1PPosition);
        move1PRot = new Vector3(Mathf.Abs(finish1PRotation.x - third1PRotation.x) / -(thirdTime * 60), 0, 0);

        move2PPos = Vector3.Distance(third2PPosition, finish2PPosition);
        move2PRot = new Vector3(Mathf.Abs(finish2PRotation.x - third2PRotation.x) / -(thirdTime * 60), 0, 0);

        Camera1P.transform.position = firstPosition;
        Camera1P.transform.eulerAngles = firstRotation;
        Camera2P.transform.position = firstPosition;
        Camera2P.transform.eulerAngles = firstRotation;
    }

    void Update ()
    {
        count++;
	    if(count < firstTime * 60)
        {          
            Camera1P.transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
            Camera2P.transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
        }
        else if(count < (firstTime + secondTime) * 60)
        {
            Camera1P.transform.position = second1PPosition;
            Camera1P.transform.eulerAngles = second1PRotation;
            Camera2P.transform.position = second1PPosition;
            Camera2P.transform.eulerAngles = second1PRotation;
        }
        else if (count < (firstTime + (secondTime * 2)) * 60)
        {
            Camera1P.transform.position = second2PPosition;
            Camera1P.transform.eulerAngles = second2PRotation;
            Camera2P.transform.position = second2PPosition;
            Camera2P.transform.eulerAngles = second2PRotation;
        }
        else if (count == (firstTime + (secondTime * 2)) * 60)
        {
            Camera1P.transform.position = third1PPosition;
            Camera1P.transform.eulerAngles = third1PRotation;

            Camera2P.transform.position = third2PPosition;
            Camera2P.transform.eulerAngles = third2PRotation;
        }
        else if(count < (firstTime + (secondTime * 2) + thirdTime) * 60)
        {
            Camera1P.transform.position = Vector3.MoveTowards(Camera1P.transform.position, finish1PPosition, move1PPos / (thirdTime * 60));
            Camera1P.transform.Rotate(move1PRot);

            Camera2P.transform.position = Vector3.MoveTowards(Camera2P.transform.position, finish2PPosition, move2PPos / (thirdTime * 60));
            Camera2P.transform.Rotate(move2PRot);
        }
        else
        {
            SceneManager.LoadScene("main");
        }

    }
}
