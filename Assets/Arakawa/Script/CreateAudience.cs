using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreateAudience : MonoBehaviour {

    //初期値は適当。
    private GameObject audience;
    private int memberNumber = 5;
    private int columnNumber = 2;
    private float membersWidth = 2.0f;
    private float columnsWidth = 1.0f;
    private float columnsHeight = 1.5f;

#if UNITY_EDITOR//プランナー向けにInspector拡張
    [CustomEditor(typeof(CreateAudience))]
    public class AudienceEditer : Editor
    {
        bool folder = false;

        public override void OnInspectorGUI()
        {
            CreateAudience editor = target as CreateAudience;

            editor.audience = EditorGUILayout.ObjectField("観客モデル", editor.audience, typeof(GameObject), true)as GameObject;

            if(folder = EditorGUILayout.Foldout(folder, "status"))
            {
                editor.memberNumber = EditorGUILayout.IntField("1列あたりの観客数", editor.memberNumber);
                editor.columnNumber = EditorGUILayout.IntField("観客列数", editor.columnNumber);
                editor.membersWidth = EditorGUILayout.FloatField("観客同士の間隔", editor.membersWidth);
                editor.columnsWidth = EditorGUILayout.FloatField("列同士の間隔", editor.columnsWidth);
                editor.columnsHeight = EditorGUILayout.FloatField("2列目以降に足される高さ", editor.columnsHeight);
            }

        }
    }
#endif


	void Start () {

        //列数
        for (int i = 0; i < columnNumber; i++)
        {
            //観客数
            for (int j = 0; j < memberNumber; j++)
            {
                Instantiate(audience,
                    new Vector3(
                        transform.position.x + (j * membersWidth),
                        transform.position.y + (i * columnsHeight),
                        transform.position.z + (i * columnsWidth)),
                    Quaternion.identity);
            }
        }
    }
	
}
