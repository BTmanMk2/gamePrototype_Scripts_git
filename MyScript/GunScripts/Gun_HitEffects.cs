using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_HitEffects : MonoBehaviour {

    private Gun_Master gunMaster;
    public GameObject defaultHitEffect;
    public GameObject enemyHitEffect;
    public GameObject bulletHole;

    private float floatInFrontOfWall = 0.00001f;

    private void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventShotDefault += SpawnDefaultHitEffect;
        gunMaster.EventShotEnemy += SpawnEnemyHitEffect;
    }

    private void OnDisable()
    {
        gunMaster.EventShotDefault -= SpawnDefaultHitEffect;
        gunMaster.EventShotEnemy -= SpawnEnemyHitEffect;
    }

    void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
        
    }

    void SpawnDefaultHitEffect(Vector3 hitPosition, Transform hitTransform, RaycastHit hit)
    {
        if (defaultHitEffect != null) {
            Instantiate(defaultHitEffect, hitPosition, Quaternion.identity);
            if (bulletHole != null) {
                GameObject bh = Instantiate(bulletHole, hit.point + (hit.normal * floatInFrontOfWall), Quaternion.LookRotation(hit.normal));
                Destroy(bh, 100);
            }
        }
        
    }

    void SpawnEnemyHitEffect(Vector3 hitPosition, Transform hitTransform, RaycastHit hit)
    {
        if (enemyHitEffect != null) {
            Instantiate(enemyHitEffect, hitPosition, Quaternion.identity);
        }
    }
}
