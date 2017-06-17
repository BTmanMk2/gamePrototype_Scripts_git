using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_ApplyDamage : MonoBehaviour {

    private Gun_Master gunMaster;
    public int damage = 10;

    private void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventShotEnemy += ApplyDamage;
        gunMaster.EventShotDefault += ApplyDamage;
    }

    private void OnDisable()
    {
        gunMaster.EventShotEnemy -= ApplyDamage;
        gunMaster.EventShotDefault -= ApplyDamage;
    }

    void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
    }

    void ApplyDamage(Vector3 hitPosition, Transform hitTransform)
    {
        /*if (hitTransform.GetComponent<Enemy_TakeDamage>() != null) {
            hitTransform.GetComponent<Enemy_TakeDamage>().ProcessDamage(damage);
        } else if (hitTransform.GetComponent<Destructible_TakeDamage>() != null) {
            hitTransform.GetComponent<Destructible_TakeDamage>().ProcessDamage(damage);
        }*/
        hitTransform.SendMessage("ProcessDamage", damage, SendMessageOptions.DontRequireReceiver);
    }
}
