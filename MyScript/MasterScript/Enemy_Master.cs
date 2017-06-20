using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Master : MonoBehaviour {

    public Transform myTarget;
    public bool isOnRoute;
    public bool isNavPaused;

    public bool isAlive = true;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventEnemyDie;
    public event GeneralEventHandler EventEnemyWalking;
    public event GeneralEventHandler EventEnemyReachedNavTarget;
    public event GeneralEventHandler EventEnemyAttack;
    public event GeneralEventHandler EventEnemyLostTarget;

    public event GeneralEventHandler EventEnemyHealthLow;
    public event GeneralEventHandler EventEnemyHealthRecovered;

    public delegate void HealthEventHandler(float health);
    public event HealthEventHandler EventEnemyDeductHealth;
    public event HealthEventHandler EventEnemyIncreaseHealth;

    public delegate void NavTargetEventHandler(Transform targetTransform);
    public event NavTargetEventHandler EventEnemySetNavTarget;

    public void CallEventEnemyDeductHealth(float health)
    {
        if (EventEnemyDeductHealth != null) {
            EventEnemyDeductHealth(health);
        }
    }

    public void CallEventEnemyIncreaseHealth(float health)
    {
        if (EventEnemyIncreaseHealth != null) {
            EventEnemyIncreaseHealth(health);
        }
    }

    public void CallEventEnemySetNavTarget(Transform targetTransform)
    {
        if(EventEnemySetNavTarget != null) {
            EventEnemySetNavTarget(targetTransform);
        }
        myTarget = targetTransform;

    }

    public void CallEventEnemyDie()
    {
        if (EventEnemyDie != null) {
            EventEnemyDie();
        }
        isAlive = false;
    }


    public void CallEventEnemyWalking()
    {
        if (EventEnemyWalking != null) {
            EventEnemyWalking();
        }
    }

    public void CallEventEnemyReachedNavTarget()
    {
        if (EventEnemyReachedNavTarget != null) {
            EventEnemyReachedNavTarget();
        }
    }

    public void CallEventEnemyAttack()
    {
        if (EventEnemyAttack != null) {
            EventEnemyAttack();
        }
    }

    public void CallEventEnemyLostTarget()
    {
        if (EventEnemyLostTarget != null) {
            EventEnemyLostTarget();
        }
    }

    public void CallEventEnemyHealthLow()
    {
        if (EventEnemyHealthLow != null) {
            EventEnemyHealthLow();
        }
    }

    public void CallEventEnemyHealthRecovered()
    {
        if (EventEnemyHealthRecovered != null) {
            EventEnemyHealthRecovered();
        }
    }
}
