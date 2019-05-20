using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject targetObject;
    private float distanceToTarget;

	// Use this for initialization
	void Start () {
        distanceToTarget = transform.position.x -
        targetObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

        // Takes the x-coordinate and moves the camera position

        float targetObjectX = targetObject.transform.position.x;
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX + distanceToTarget;
        transform.position = newCameraPosition;



    }
}
