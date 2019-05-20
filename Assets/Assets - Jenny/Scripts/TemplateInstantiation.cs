using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateInstantiation : MonoBehaviour
{
    public Vector3 playerPos;
    public float[] SpawnRateRange = new float[2];
    public float[] SpawnLocationRangeX = new float[2];
    public float nextSpawn;
    public GameObject item;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("nerd_run_1").transform.position;
        if (Time.time > nextSpawn)
        {
            Instantiate(item, new Vector3((float)(playerPos.x + Random.Range(SpawnLocationRangeX[0], SpawnLocationRangeX[1])), -4.17f, 0f), transform.rotation);
            nextSpawn += Random.Range(SpawnRateRange[0], SpawnRateRange[1]);
        }
    }
}
