using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class WalkingGoose : MonoBehaviour
{
    //Components of the goose
    private SpriteRenderer sr;
    private Transform transform;

    //In order to toggle the sprite animations
    private int currentsprite = 0;
    public Sprite[] goose = new Sprite[3];
    public Sprite idle;
    public Sprite[] deathAnim = new Sprite[9];

    //
    private float gst = 0;
    public float speed;
    private float dst;
    public float decidetime;

    //
    private bool dead = false;
    private bool fullydead = false;

    //
    private bool panicked = false;
    public float panicspeed;
    public float panicdecidetime;
    // Use this for initialization

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        transform = gameObject.GetComponent<Transform>();
    }



    // Update is called once per frame

    void Update()
    {
        if (gst > (1 / Mathf.Abs(speed)))
        {
            if (!dead)
            {
                if (speed == 0)
                {
                    sr.sprite = idle;
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
            else
            {
                if (!fullydead)
                {
                    currentsprite = (currentsprite + 1) % 6;
                    sr.sprite = deathAnim[currentsprite];
                    transform.position = new Vector3(transform.position.x,
                                          transform.position.y + (speed / 100), 0);
                }
                else {
                    transform.position = new Vector3(transform.position.x,
                                          transform.position.y - (speed / 100), 0);
                }

                if (transform.position.y < -20)
                {
                    Object.Destroy(this.gameObject);
                }
                gameObject.GetComponent<Collider2D>().enabled = false;
            }

        }
        else { gst += Time.deltaTime; }

        if (dst > decidetime)
        {
            if (!dead)
            {
                dst = 0;
                decideDirection(Random.Range(0f, 10f));
            }
            else
            {
                sr.sprite = deathAnim[6];
                fullydead = true;
            }
        }
        else { dst += Time.deltaTime; }

        if (panicked)
        {
            speed = panicspeed;
            decidetime = panicdecidetime;
        }
    }

    void decideDirection(float a)
    {
        if (a < 7)
        {
            if (speed == 0)
            {
                speed = 5;
                sr.flipX = false;
            }
        }
        else if (a < 9)
        {
            speed = -speed;
            sr.flipX = !sr.flipX;
        }
        else
        {
            if (speed != 0)
            {
                speed = 0;
                sr.sprite = idle;
            }
            else
            {
                speed = 5;
                sr.flipX = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            Object.Destroy(collision.gameObject);
            dead = true;
            dst = 0;
            panicked = true;
        }
    }

}
