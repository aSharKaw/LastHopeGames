using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAround : MonoBehaviour {

    [SerializeField]
    private GameObject camera1P, camera2P;

    //[SerializeField]
    //private int 

    void Start () {
		
	}

	void Update () {
	    	camera1P.transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
    }
}
