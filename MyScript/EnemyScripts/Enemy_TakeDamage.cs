using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TakeDamage : MonoBehaviour {

    private Enemy_Master enemyMaster;
    public float damageMultiplier = 1;
    public bool shouldRemoveCollider;

    private void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += RemoveThis;
    }

    private void OnDisable()
    {
        enemyMaster.EventEnemyDie -= RemoveThis;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void SetInitialReferences()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();
    }

    public void ProcessDamage(int damage)
    {
        int damageToApply = (int)(damage * damageMultiplier);
        enemyMaster.CallEventEnemyDeductHealth(damageToApply);
    }

    void RemoveThis()
    {
        if (shouldRemoveCollider) {
            if (GetComponent<Collider>() != null) {
                Destroy(GetComponent<Collider>());
            }
            if (GetComponent<Rigidbody>() != null) {
                Destroy(GetComponent<Rigidbody>());
            }
        }
        Destroy(this);
    }
}
