using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
    public GameObject obj;
    public float spawnRate;
    private float nextSpawn = 2f;
    public Vector3 playerPos;
    public Vector3 newPos;
    public Vector3 newRot = new Vector3(0, 0, 0);

    //public float speed;

    
     void Start () {
        spawnRate = Random.Range(3, 10);
        //speed = Random.Range(2, 5);
     }   
        
        
        // Update is called once per frame


    void Update () {
        playerPos = GameObject.Find("nerd_run_1").transform.position;
        newPos = new Vector3(playerPos.x + 20, 0, 0);
        if (Time.time > nextSpawn)
        {
            newPos.y = Random.Range(-4, 4);
            //newRot.x = Random.Range(-60, 60);
            //newRot.y = Random.Range(-60, 60);
            GameObject clone = Instantiate(obj, newPos, transform.rotation);
            //transform.Rotate(0, 0, Random.Range(-30, 30));
            //clone.velocity = transform.forward * speed;
            nextSpawn = Time.time + spawnRate;
            spawnRate = Random.Range(5, 10);
            Debug.Log(spawnRate);
            //speed = Random.Range(2, 5);
        }
    }


}
