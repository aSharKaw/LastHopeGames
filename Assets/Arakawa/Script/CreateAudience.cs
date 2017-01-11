using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAudience : MonoBehaviour {

    [SerializeField, Tooltip("観客モデル")]
    private GameObject audience;

    [SerializeField, Tooltip("1列あたりの観客数")]
    private int memberNumber;

    [SerializeField, Tooltip("観客列数")]
    private int columnNumber;

    [SerializeField, Tooltip("観客同士の間隔")]
    private float membersWidth;

    [SerializeField, Tooltip("列同士の間隔")]
    private float columnsWidth;

    [SerializeField, Tooltip("2列目以降に足される高さ")]
    private float columnsHeight;

	// Use this for initialization
	void Start () {
        //数値が入力されてない場合
        memberNumber = 5;
        columnNumber = 2;
        membersWidth = 2.0f;
        columnsWidth = 1.0f;
        columnsHeight = 1.5f;


        //列数
        for (int i = 0; i < columnNumber; i++)
        {
            //観客数
            for (int j = 0; j < memberNumber; j++)
            {
                Instantiate(audience,
                    new Vector3(
                        transform.position.x + (j * membersWidth),
                        transform.position.y + (i * columnsWidth),
                        transform.position.z + (i * columnsHeight)),
                    Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
