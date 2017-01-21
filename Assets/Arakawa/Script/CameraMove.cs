using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField]
    private GameObject Camera1P;
    [SerializeField]
    private GameObject Camera2P;

    private int count = 30;

    private int firstTime = 6;
    private int secondTime = 3;
    private int thirdTime = 3;

    private Vector3 firstPosition = new Vector3(14, 17, -14);
    private Vector3 firstRotation = new Vector3(30, -48, -13);

    private Vector3 second1PPosition = new Vector3(-9, 4, -16);
    private Vector3 second1PRotation = new Vector3(12, -100, 1);

    private Vector3 third1PPosition = new Vector3(0, 12, 0);
    private Vector3 third1PRotation = new Vector3(90, 90, 0);
    private Vector3 third2PRotation = new Vector3(90, -90, 0);

    private Vector3 finish1PPosition = new Vector3(-4, 4, 0);
    private Vector3 finish1PRotation = new Vector3(0, 90, 0);

    private Vector3 move1PPos = Vector3.zero;
    private Vector3 move1PRot = Vector3.zero;

    void Start ()
    {
        move1PPos = new Vector3(
            (third1PPosition.x - finish1PPosition.x) / thirdTime,
            (third1PPosition.y - finish1PPosition.y) / thirdTime,
            (third1PPosition.z - finish1PPosition.z) / thirdTime);

        move1PRot = new Vector3(
            (third1PRotation.x - finish1PRotation.x) / thirdTime,
            (180) / thirdTime,
            (third1PRotation.z - finish1PRotation.z) / thirdTime);
    }
	
	void Update ()
    {
        count++;
	    if(count < firstTime * 60)
        {
            Camera1P.transform.position = firstPosition;
            Camera1P.transform.eulerAngles = firstRotation;
            Camera2P.transform.position = firstPosition;
            Camera2P.transform.eulerAngles = firstRotation;
        }
        else if(count < (firstTime + secondTime) * 60)
        {
            Camera1P.transform.position = second1PPosition;
            Camera1P.transform.eulerAngles = second1PRotation;
            Camera2P.transform.position = second1PPosition;
            Camera2P.transform.eulerAngles = second1PRotation;
        }
        else if (count == (firstTime + secondTime) * 60)
        {
            Camera1P.transform.position = third1PPosition;
            Camera1P.transform.eulerAngles = third1PRotation;
        }
        else if(count < (firstTime + secondTime + thirdTime) * 60)
        {
            Debug.Log(move1PPos);
            Camera1P.transform.Translate(move1PPos.x / 60, move1PPos.y / 60, 0);
            Camera1P.transform.Rotate(-move1PRot.x / 60, move1PRot.y / 60, 0);
            Camera1P.transform.eulerAngles = new Vector3(
                Camera1P.transform.rotation.eulerAngles.x,
                Camera1P.transform.rotation.eulerAngles.y,
                0);
        }

    }
}
