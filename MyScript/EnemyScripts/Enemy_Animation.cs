using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Animator myAnimator;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyWalking += SetAnimationToWalk;
        enemyMaster.EventEnemyReachedNavTarget += SetAnimationToIdle;
        enemyMaster.EventEnemyAttack += SetAnimationToAttack;
        enemyMaster.EventEnemyDeductHealth += SetAnimationToHit;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyWalking -= SetAnimationToWalk;
        enemyMaster.EventEnemyReachedNavTarget -= SetAnimationToIdle;
        enemyMaster.EventEnemyAttack -= SetAnimationToAttack;
        enemyMaster.EventEnemyDeductHealth -= SetAnimationToHit;
    }


    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<Animator>() != null) {
            myAnimator = GetComponent<Animator>();
        }
    }

    void SetAnimationToWalk()
    {
        if (myAnimator != null) {
            if (myAnimator.enabled) {
                myAnimator.SetBool("isPursuing", true);
            }
        }
    }

    void SetAnimationToIdle()
    {
        if (myAnimator != null) {
            if (myAnimator.enabled) {
                myAnimator.SetBool("isPursuing", false);
            }
        }
    }

    void SetAnimationToAttack()
    {
        if (myAnimator != null) {
            if (myAnimator.enabled) {
                myAnimator.SetTrigger("Attack");
            }
        }
    }

    void SetAnimationToHit(float dummy)
    {
        if (myAnimator != null) {
            if (myAnimator.enabled) {
                myAnimator.SetTrigger("Hit");
            }
        }
    }

    

    
}
