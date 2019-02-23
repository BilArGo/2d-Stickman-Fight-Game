using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float curHealth;
    public float healthRestoringSpeed;
    public bool alive = true;

    void Awake()
    {
        curHealth = health;
        alive = true;
    }

    void Update()
    {
        if (curHealth != 0) curHealth += Time.deltaTime * healthRestoringSpeed;
        else alive = false;

        curHealth = Mathf.Clamp(curHealth, 0, health);

    }
}
