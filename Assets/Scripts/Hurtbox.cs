using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {

    public float damageResistancy = 0;
    public Rigidbody2D rb;
    public Health hp;
    float v = 0.001f;
    Vector3 force;

    int knockbackFrame;
    public StateManager sm;


    void Start()
    {
    }

    void Update()
    {
        v = -v;
        transform.position += transform.right * v;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player Hitbox" && MyClass.OldestParent(gameObject).tag != "Player")
        {

            if (Time.frameCount > knockbackFrame + 10)
            {
                Hitbox hb = other.gameObject.GetComponent<Hitbox>();
                hp.curHealth -= hb.damage;

                if (hb.damage > damageResistancy && hp.curHealth > 0)
                {
                    HitStun();
                }
                GameObject enemy = MyClass.OldestParent(other.gameObject);
                float dir = Mathf.Sign(enemy.transform.position.x - transform.position.x);
                force = (-Vector3.right * other.gameObject.GetComponent<Hitbox>().horizontalKnockback * dir) + (Vector3.up * other.gameObject.GetComponent<Hitbox>().verticalKnockback);

                ApplyForce(force);
            }
        }

        if (other.gameObject.tag == "Enemy Hitbox" && MyClass.OldestParent(gameObject).tag != "Enemy")
        {

            if (Time.frameCount > knockbackFrame + 10)
            {
                Hitbox hb = other.gameObject.GetComponent<Hitbox>();
                hp.curHealth -= hb.damage;

                if (hb.damage > damageResistancy && hp.curHealth > 0)
                {
                    HitStun();
                }
                GameObject enemy = MyClass.OldestParent(other.gameObject);
                float dir = Mathf.Sign(enemy.transform.position.x - transform.position.x);
                force = (-Vector3.right * other.gameObject.GetComponent<Hitbox>().horizontalKnockback * dir) + (Vector3.up * other.gameObject.GetComponent<Hitbox>().verticalKnockback);

                ApplyForce(force);
            }
        }
    }



    void ApplyForce(Vector3 direction)
    {
        if (sm.alive)
        {
            rb.AddForce(direction * Time.deltaTime * 60);
            knockbackFrame = Time.frameCount;
        }
    }

    void HitStun()
    {
        sm.HitStun();
    }
}
