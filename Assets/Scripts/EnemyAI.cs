using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float delayBeforeHit;
    public float delayBetweenHits;
    public float neededAttackDis;
    public enum EnemyState {Move, Stop, Attack}
    public EnemyState state = EnemyState.Attack;

    //Some handy variables
    float dis; // Distance
    float hDis;
    bool pointing; // Is the enemy pointing at the player
    Vector3 offset; // difference between enemy and player
    Vector3 pP; // player position
    Vector3 eP; // enemy position
    float hDir;

    bool hs; // Can be use to detect Hitstun exits.
    bool canAttack;

    GameObject player;

    public Animator anim;
    public StateManager sm;
    
    EnemyMovement em;

    private void Start ()
    {
        em = gameObject.GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        canAttack = true;
    }

    private void Update()
    {
        {
            pP = player.transform.position;
            eP = transform.position;
            dis = Vector3.Distance(eP, pP);
            hDis = Mathf.Abs(offset.x);
            offset = pP - eP;
            if (Mathf.Sign(transform.localScale.x) == Mathf.Sign(offset.x)) pointing = true;
            else pointing = false;
            em.h = hDir;
        } //handy variable declarations...

        if (state == EnemyState.Attack)
        {
            bool nearEnemy = false;
            if (pointing && hDis <= neededAttackDis) nearEnemy = true;

            if (nearEnemy)
            {
                hDir = 0;
                if (canAttack)
                {
                    if (MyClass.CheckTransitionName(anim, "Stickman Punch 1-1 -> Idle", 2))
                    {
                        Invoke("DeclareAttack", delayBetweenHits);
                        canAttack = false;
                        print("Fast Hit");
                    }

                    if (MyClass.CheckStatenName(anim, "Idle", 2)) 
                    {
                        Invoke("DeclareAttack", delayBeforeHit);
                        canAttack = false;
                        print("Slow Hit");
                    }
                }
            }
            else
            {
                hDir = Mathf.Sign(offset.x);
                sm.ChangeState("Stickman Run");
            }
        }


    }

    void DeclareAttack()
    {
        if ((MyClass.CheckTransitionName(anim, "Stickman Punch 1-1-1 -> Idle", 2) || MyClass.CheckStatenName(anim, "Idle", 2)) && !hs)
        {
            sm.DeclareAttack("Stickman Punch 1-1");
            canAttack = true;
        }
    }
}
