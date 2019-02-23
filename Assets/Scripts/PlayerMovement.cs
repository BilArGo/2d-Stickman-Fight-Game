using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public static float speedMultiplier = 1;



    public bool onGround;
    int jumpTime = 2;
    float h;
    float v;


    bool a;

    Rigidbody2D rb;
    public StateManager sm;
    //SpriteRenderer sr;

    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        //sr = gameObject.GetComponent<SpriteRenderer>();

    }

    void Update ()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //rb.velocity = new Vector2(speed * h * speedMultiplier * privateMultiplier,rb.velocity.y);
        if(sm.alive) rb.position += Vector2.right * speed * h * Time.deltaTime; //rb.MovePosition(transform.position + Vector3.right * speed * h * Time.deltaTime);


        if (h != 0)
        {
            transform.localScale = new Vector3(h, transform.localScale.y, transform.localScale.z);
        }
        if (v == 0) a = true;
        if (v == 1 && sm.alive) Jump();

        if (h != 0 && sm.state != "Stickman Stun 1") sm.ChangeState("Stickman Run");
        else sm.ChangeState(null);

        //if (h == -1  && speedMultiplier != 0) sr.flipX = true;
        //if (h == 1 && speedMultiplier != 0) sr.flipX = false;

        /*
        RaycastHit2D[] gHits = Physics2D.RaycastAll(transform.position, -Vector3.up, 5);
        for (int i = 0; i < gHits.Length; i++)
        {
            if (gHits[i].collider.gameObject.tag == "ground" || gHits[i].collider.gameObject.tag == "stun")
            {
                onGround = true;
                jumpTime = 2;
            }
        }
        */
    }

    void Jump()
    {
        if (a && jumpTime != 0)
        {
            rb.velocity = (Vector2.up * jumpForce);
            jumpTime--;
            onGround = false;
        }
        a = false;
    }
  
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumpTime = 2;
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onGround = false;
        }
    }
}
