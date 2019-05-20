using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBTMoveScript : MonoBehaviour {
    public Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = startPos + new Vector3(Mathf.Sin(Time.time), 0.0f, 0.0f);
	}
}
