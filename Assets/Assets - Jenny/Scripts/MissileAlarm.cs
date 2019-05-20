using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MissileAlarm : MonoBehaviour
{
    private int currentsprite = 0;
    private SpriteRenderer sr;
    public Sprite[] alarm = new Sprite[3];
    private float ast = 0;
    public float speed;
    private float timeSinceStart = 0;
    private bool isCollide = false;
    private Transform tr;
    private Rigidbody2D rb;
    private int forwardMovementSpeed;
    public GameObject PLAYER; 

    // Use this for initialization
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        tr = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceStart < 1.5f)
        { 
            float a = PLAYER.GetComponent<Rigidbody2D>().velocity.x;
            //rb.velocity = PLAYER.GetComponent<Rigidbody2D>().velocity;
            rb.velocity = new Vector2(Mathf.Sqrt(Time.time * 3.0f), 0);
            //tr.position = new Vector3((float)(tr.position.x + Mathf.Sqrt(Time.time)), (float)tr.position.y, 0f);
            if (ast > speed)
            {
                currentsprite = (currentsprite + 1) % 2;
                sr.sprite = alarm[currentsprite];
                ast = 0;
            }
            else { 
                ast += Time.deltaTime;
            }
        } else if (1.2<=timeSinceStart && timeSinceStart < 1.7)
        {
            sr.sprite = alarm[2];
        } else{
            transform.Translate((-Time.deltaTime*5) * Mathf.Sqrt(Time.time),0,0,Space.World);
        }

        timeSinceStart += Time.deltaTime;

        if (gameObject.GetComponent<Transform>().position.x < -50)
        {
            Object.Destroy(gameObject);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

}