using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nerdcontrol : MonoBehaviour {

    public float jetpackForce = 75000.0f;
    private Rigidbody2D playerRigidbody;
    private Transform tr;
    public float forwardMovementSpeed = 3.0f;
    public Transform groundCheckTransform;
    private bool isGrounded;
    private bool isDead;
    public LayerMask groundCheckLayerMask;
    private Animator nerdAnimator;
    public ParticleSystem jetpack;
    private Collider2D playerColl;
    private float deadcalltime;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        nerdAnimator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        playerColl = GetComponent<Collider2D>();
    }

    void UpdateGroundedStatus()
    {
        // creates circle of radiu0.1 at groundCheck object and if it overlaps object that has a layer
        //specified in groundCheckLayerMask then mouse is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
        nerdAnimator.SetBool("isGrounded", isGrounded);
    }

    void AdjustJetpack(bool jetpackActive)
    {
        var jetpackEmission = jetpack.emission;
        jetpackEmission.enabled = !isGrounded;
        if (jetpackActive)
        {
            jetpackEmission.rateOverTime = 300.0f;
        }
        else
        {
            jetpackEmission.rateOverTime = 75.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            Object.Destroy(collision.gameObject);
            isDead = true;
            nerdAnimator.SetBool("isDead", isDead);
        }
    }

    void OnCollisionEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Killer")) {
            isDead = true;
            nerdAnimator.SetBool("isDead", isDead);
        }
    }

    //private void OnCollisionEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Killer"))
    //    {
     //       isDead = true;
       //     nerdAnimator.SetBool("isDead", isDead);
        //}
    //}


    void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Fire1");

        AdjustJetpack(jetpackActive);
        if (jetpackActive && (!isDead))
        {
            //Vector2 hi;
            //hi = new Vector2(0, jetpackForce);
            //Debug.Log(hi);
            //tr.position = new Vector3(tr.position.x, tr.position.y + jetpackForce, 0);
            //playerRigidbody.AddForce(hi);
            playerRigidbody.gravityScale = -1;


        }
        else { playerRigidbody.gravityScale = 1; }

        forwardMovementSpeed = Mathf.Sqrt(Time.time * 3.0f);

        if (!isDead || !isGrounded)
        {
            Vector2 newVelocity = playerRigidbody.velocity;
            newVelocity.x = forwardMovementSpeed;
            playerRigidbody.velocity = newVelocity;  // Adds x-component velocity without changing y-component
        }
        //Vector2 newVelocity = playerRigidbody.velocity;
        //newVelocity.x = forwardMovementSpeed;
        //playerRigidbody.velocity = newVelocity;  // Adds x-component velocity without changing y-component

        AdjustJetpack(jetpackActive);
        UpdateGroundedStatus();

    }



    // Update is called once per frame
    void Update () {
        if (isDead && isGrounded)
        {
            if (deadcalltime > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                deadcalltime += Time.deltaTime;
            }
        }
	}
}
