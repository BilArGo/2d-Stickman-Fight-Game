using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public int attackType;
    public int lastAttackType;
    public int comboCount;
    public bool idle;



    public StateManager sm;

    void Start ()
    {
        comboCount = 1;
    }

    void Update ()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.T)) attackType = 11;
        if (Input.GetKeyDown(KeyCode.T) && v == -1) attackType = 12;
        if (Input.GetKeyDown(KeyCode.Y)) attackType = 21;
        if (Input.GetKeyDown(KeyCode.Y) && v == -1) attackType = 22;
        //if (Input.GetKeyUp(KeyCode.T)) attackType = 0;


        if (attackType == 11)
        {
            if (attackType == lastAttackType && comboCount <= 3 && (sm.CheckCurTransaction("Stickman Punch 1-1-1 -> Idle", 2) || sm.CheckCurTransaction("Stickman Punch 1-1-2 -> Idle", 2)))
            {
                comboCount++;
                sm.DeclareAttack("Stickman Punch 1-1-" + comboCount);
                attackType = 0;
            }
            else if (sm.CheckCurTransaction("Stickman Punch 1-1-1 -> Idle", 2) || sm.CheckCurAnim("Idle", 2))
            {
                sm.DeclareAttack("Stickman Punch 1-1-1");
                comboCount = 1; attackType = 0;

            }
            lastAttackType = 11;

        }

        else if (attackType == 0 && (sm.CheckCurTransaction("Stickman Punch 1-1-1 -> Idle", 2) || sm.CheckCurTransaction("Stickman Punch 1-1-2 -> Idle", 2))) lastAttackType = 0;

        if (attackType == 12 && (sm.CheckCurAnim("Idle", 2)))
        {
            sm.DeclareAttack("Stickman Punch 1-2" +
                "");
            lastAttackType = 12; attackType = 0;
        }

        if (attackType == 21 && (sm.CheckCurAnim("Idle", 2)))
        {
            sm.DeclareAttack("Stickman Punch 2-1");
            lastAttackType = 21; attackType = 0;
        }

        if (attackType == 22 && (sm.CheckCurAnim("Idle", 2)))
        {
            sm.DeclareAttack("Stickman Punch 2-2");
            lastAttackType = 22; attackType = 0;
        }
        


        idle = (sm.anim.GetAnimatorTransitionInfo(2).IsName("Stickman Kick 1-1-1 -> Idle"));


        //attackType = 0;


    }
}
