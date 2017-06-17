using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_HitEffects : MonoBehaviour {

    private Melee_Master meleeMaster;
    public GameObject defaultHitEffect;
    public GameObject enemyHitEffect;

    private void OnEnable()
    {
        SetInitialReferences();
        meleeMaster.EventHit += SpawnHitEffect;
    }

    private void OnDisable()
    {
        meleeMaster.EventHit -= SpawnHitEffect;
    }

    void SetInitialReferences()
    {
        meleeMaster = GetComponent<Melee_Master>();
    }

    void SpawnHitEffect(Collision hitCollision, Transform hitTransform)
    {
        Quaternion quatAngle = Quaternion.LookRotation(hitCollision.contacts[0].normal);
        if (hitTransform.GetComponent<Enemy_TakeDamage>() != null) {
            Instantiate(enemyHitEffect, hitCollision.contacts[0].point, quatAngle);
        }else {
            Instantiate(defaultHitEffect, hitCollision.contacts[0].point, quatAngle);
        }
    }
}
