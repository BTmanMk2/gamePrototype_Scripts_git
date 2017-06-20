using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DeathAnimation : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Animator myAnimator;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += PlayDeathAnimation;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= PlayDeathAnimation;
    }

    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<Animator>() != null) {
            myAnimator = GetComponent<Animator>();
        }
    }

    void PlayDeathAnimation()
    {
        if (myAnimator != null) {
            myAnimator.SetTrigger("Dead");
        }
    }
}
