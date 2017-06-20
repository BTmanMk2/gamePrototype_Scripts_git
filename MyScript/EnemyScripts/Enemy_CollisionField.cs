using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CollisionField : MonoBehaviour {

    private Enemy_Master enemyMaster;
    private Rigidbody rigidbodyStrikingMe;
    private int damageToApply;
    public float massRequirement = 50;
    public float speedRequirement = 5;
    private float damageFactor = 0.1f;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DisableThis;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
    }

    void SetInitialReferences()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null) {
            rigidbodyStrikingMe = other.GetComponent<Rigidbody>();
            if (rigidbodyStrikingMe.mass >= massRequirement &&
                rigidbodyStrikingMe.velocity.sqrMagnitude >= speedRequirement * speedRequirement) {
                damageToApply = (int)(damageFactor * rigidbodyStrikingMe.mass * rigidbodyStrikingMe.velocity.magnitude);
                //Debug.Log("Damage:" + damageToApply);
                enemyMaster.CallEventEnemyDeductHealth(damageToApply);
            }
        }
    }

    void DisableThis()
    {
        gameObject.SetActive(false);
    }
}
