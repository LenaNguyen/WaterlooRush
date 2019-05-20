using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingGooseStart : MonoBehaviour
{
    private int currentsprite = 0;
    private SpriteRenderer sr;
    private Transform transform;
    public Sprite[] goose = new Sprite[3];
    private float gst = 0;
    public float speed;
    // Use this for initialization
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        transform = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gst > (1 / speed))
        {
            if (transform.position.x > 7)
            {
                transform.position = new Vector3(-5, transform.position.y, 0);
            }
            else
            {
                currentsprite = (currentsprite + 1) % 3;
                sr.sprite = goose[currentsprite];
                gst = 0;
                transform.position = new Vector3(transform.position.x + (speed / 25),
                                      transform.position.y, 0);
            }
        }
        else { gst += Time.deltaTime; }

    }

}