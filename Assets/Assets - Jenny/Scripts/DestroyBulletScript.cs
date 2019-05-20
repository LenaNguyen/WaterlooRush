using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletScript : MonoBehaviour
{
    public Vector3 playerPos;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("nerd_run_1").transform.position;
        if (gameObject.GetComponent<Transform>().position.y < -4.5 || gameObject.GetComponent<Transform>().position.x < playerPos.x - 3)
        {
            Object.Destroy(gameObject);
        }
    }
}
