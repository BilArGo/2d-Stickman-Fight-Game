using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float x;

    void Start()
    {
        Invoke("DoSomething", 2);
    }

    void Update()
    {

        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(9, 9);
        Physics2D.IgnoreLayerCollision(10, 10);

    }

    /*
             if (!pointing)
        {
            state = EnemyState.Stop;
        }

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Stickman Stun 1") && sm.alive && state != EnemyState.DeclareAttack)
        {
            state = EnemyState.Attack;
        }
        else
        {
            Stop();
        }

        if (hDis > minDistance)
        {
            state = EnemyState.Attack;
        }

        

        //StartCoroutine("Delay");

    }

    public void Jump()
    {
        
    }

    public void Stop()
    {
        em.h = 0;
    }

    public void DeclareAttack(string attackIndex)
    {
        sm.DeclareAttack("Stickman Punch " + attackIndex);
    }

    public void Attack()
    {
        em.h = Mathf.Sign(offset.x);
        sm.ChangeState("Stickman Run");

        if (hDis < minDistance)
        {
            state = EnemyState.DeclareAttack;
        }

    }

    public void Dash()
    {

    }

    IEnumerator Brain()
    {
        EnemyState lastState = EnemyState.Null;

        while (true)
        {
            if (lastState != state && state == EnemyState.DeclareAttack)
            {
                yield return new WaitForSeconds(0.3f);
                DeclareAttack("1-1");
                lastState = state;
            }
            else if (state == EnemyState.DeclareAttack) DeclareAttack("1-1");


            if (lastState != state && state == EnemyState.Attack)
            {
                yield return new WaitForSeconds(Random.value * 2);
                Attack();
                lastState = state;
            }
            else if (state == EnemyState.Attack) Attack();


            yield return new WaitForSeconds(0.02f); }
    }
    */

    void DoSomething()
    {
        print("Hello World");
    } 

}
