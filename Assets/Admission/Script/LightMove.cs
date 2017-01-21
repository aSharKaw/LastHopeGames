using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    //angle変更インターバル
    private int time;
    private int count;
    [SerializeField, Range(1, 10)]
    private int minTime;
    [SerializeField, Range(1, 10)]
    private int maxTime;
    
    //移動角度数
    private float angle;
    [SerializeField, Range(0.1f, 5.0f), Space(8)]
    private float minAngle;
    [SerializeField, Range(0.1f, 5.0f)]
    private float maxAngle;

    void Start()
    {
        time = Random.Range(60 * minTime, 60 * maxTime);
        count = 0;
        angle = Random.Range(minAngle, maxAngle);
    }

    void Update()
    {
        transform.Rotate(0, angle, 0, Space.World);
        //Debug.Log(angle);
        if (time < count)
        {
            count = 0;
            angle = Random.Range(minAngle, maxAngle);
        }

        count++;
    }
}
