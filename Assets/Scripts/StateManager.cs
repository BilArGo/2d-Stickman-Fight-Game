using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    /*
        Priority Order:
       =================
       3 - Attack
       3 - Jump
       2 - Run
       1 - Idle
    */



    public string state;
    public string attackState;
    public float timeScale;
    [HideInInspector]public bool alive;


    public Animator anim;
    public Health health;


    void Awake()
    {
        alive = true;
    }

    void Update()
    {
        if (alive)
        {
            if (state != null)
                anim.Play(state, 1);
            Time.timeScale = timeScale;
        }
        else Dead();

        alive = health.alive;
    }

    public void ChangeState(string s)
    {
        if(state != "Stickman Stun 1" && alive) state = s;
    }

    public void DeclareAttack(string attackState)
    {
        if (alive)
        {
            anim.Play(attackState, 2);
        }
    }

    public void HitStun ()
    {
        if (alive)
        {
            anim.Play("Stickman Stun 1", 0);
            anim.Play("Stickman Stun 1", 1);
            anim.Play("Stickman Stun 1", 2);
        }
    }

    void Dead()
    {
        anim.Play("Stickman Die 1", 0);

    }

    public bool CheckCurAnim(string animName,int layerIndex)
    {
        return anim.GetCurrentAnimatorStateInfo(layerIndex).IsName(animName);
    }

    public bool CheckCurTransaction(string animName, int layerIndex)
    {
        return anim.GetAnimatorTransitionInfo(layerIndex).IsName(animName);
    }
}
