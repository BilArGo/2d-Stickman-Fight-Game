using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

    public string[] affectedTags;
    public bool detected;
    public float horizontalKnockback;
    public float verticalKnockback;

    public float damage;
    BoxCollider2D bc;

    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hurt Box")
        detected = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hurt Box")
        detected = false;
    }

    public void ColliderActive(bool active)
    {
        bc.enabled = active;

    }
}
