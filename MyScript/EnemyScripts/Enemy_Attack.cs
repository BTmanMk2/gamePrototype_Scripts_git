﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Transform attackTarget;
    private Transform myTransform;
    public float attackRate = 1;
    private float nextAttack;
    public float attackRange = 3.5f;
    public int attackDamage = 10;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DisableThis;
        enemyMaster.EventEnemySetNavTarget += SetAttackTarget;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
        enemyMaster.EventEnemySetNavTarget -= SetAttackTarget;
    }

    // Update is called once per frame
    void Update () {
        TryToAttack();
	}

    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        myTransform = transform;
    }

    void SetAttackTarget(Transform targetTransform)
    {
        attackTarget = targetTransform;
    }

    void TryToAttack()
    {
        if (attackTarget != null) {
            if (Time.time > nextAttack) {
                nextAttack = Time.time + attackRate;

                if (Vector3.Distance(myTransform.position, attackTarget.position) <= attackRange) {
                    Vector3 lookAtVector = new Vector3(attackTarget.position.x, myTransform.position.y, attackTarget.position.z);
                    myTransform.LookAt(lookAtVector);
                    enemyMaster.CallEventEnemyAttack();
                    enemyMaster.isOnRoute = false;
                }
            }
            
        }
    }

    public void OnEnemyAttack() //Called by attack animation
    {
        if (attackTarget != null) {
            if(Vector3.Distance(myTransform.position,attackTarget.position)<=attackRange
                && attackTarget.GetComponent<Player_Master>() != null) {
                Vector3 toOther = attackTarget.position - myTransform.position;
                //Debug.Log(Vector3.Dot(toOther, myTransform.forward).ToString());

                if(Vector3.Dot(toOther, myTransform.forward) > 0.5f) {
                    attackTarget.GetComponent<Player_Master>().CallEventPlayerHealthDeduction(attackDamage);

                }
            }
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
