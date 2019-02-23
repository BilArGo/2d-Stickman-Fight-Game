using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    [HideInInspector]public float speedMultiplier = 1;



    [HideInInspector]public bool onGround;
    [HideInInspector]public int jumpTime = 2;
    [HideInInspector]public float h;


    bool a;

    Rigidbody2D rb;
    public StateManager sm;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(sm.alive)rb.position += Vector2.right * speed * h * Time.deltaTime;
        if (h != 0) transform.localScale = new Vector3(h, transform.localScale.y, transform.localScale.z);

    }

    public void Jump()
    {
        if (jumpTime != 0)
        {
            rb.velocity = (Vector2.up * jumpForce);
            jumpTime--;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jumpTime = 1;
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
