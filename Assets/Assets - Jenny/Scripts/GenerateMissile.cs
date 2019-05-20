using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMissile : MonoBehaviour {
    public Rigidbody2D Missile;
    public Rigidbody2D Bullet;
    public float speed = 3;
    private float timeSinceStart = 0;
    private float lastGenerate = 0;
    private float clickInterval = 0;
    private bool isFirst;
    public Vector3 playerPos;
    void FireRocket()
    {
        float y = Random.Range(-1.0f, 3.0f);
        speed = Random.Range(5.5f, 6.0f)* Mathf.Sqrt(timeSinceStart);
        Rigidbody2D rocketClone = (Rigidbody2D)Instantiate(Missile, new Vector3(playerPos.x + 15f,y,0), transform.rotation);
        rocketClone.velocity = transform.forward * speed;

    }

    // Calls the fire method when holding down ctrl or mouse
    void Update()
    {
        playerPos = GameObject.Find("nerd_run_1").transform.position;
        timeSinceStart += Time.deltaTime;
        if (lastGenerate>5)
        {
            lastGenerate = 0;
            FireRocket();
        } else {
            lastGenerate += Time.deltaTime;
        }
        if (Input.GetMouseButton(0))
        {

            if( clickInterval>0.15f){
                Rigidbody2D bulletClone = (Rigidbody2D)Instantiate(Bullet, new Vector3(playerPos.x, playerPos.y - 1, 0), transform.rotation);
                clickInterval = 0;
                isFirst = true;
            } else if (isFirst){
                //camera.main.screentoworld
                Rigidbody2D bulletClone = (Rigidbody2D)Instantiate(Bullet, new Vector3(playerPos.x, playerPos.y - 1, 0), transform.rotation);
                isFirst = false;
            }
            else {
                clickInterval += Time.deltaTime;
            }
           
        }
    }

    // Use this for initialization
    void Start () {
        isFirst = true;

    }

}
