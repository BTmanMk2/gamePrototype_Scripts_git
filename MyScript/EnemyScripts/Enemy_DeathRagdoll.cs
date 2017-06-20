using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DeathRagdoll : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Animator myAnimator;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DisableAnimator;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableAnimator;
    }

    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<Animator>() != null) {
            myAnimator = GetComponent<Animator>();
        }
    }

    void DisableAnimator()
    {
        if (myAnimator != null) {
            myAnimator.enabled = false;
        }
    }
}
