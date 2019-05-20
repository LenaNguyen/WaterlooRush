using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {
    public Transform tr;
    //public float rate = 0.1f;
    //public float nextTime = 0.1f;
	// Use this for initialization
	void Start () {
        tr = gameObject.GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update() {
        tr.position = new Vector3(tr.position.x - 1, tr.position.y, 0);
    }
}
