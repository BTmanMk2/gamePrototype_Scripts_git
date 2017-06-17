using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_ApplyForce : MonoBehaviour {

    private Gun_Master gunMaster;
    private Transform myTransfrom;
    public float forceToApply = 300;

    private void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventShotDefault += ApplyForce;
    }

    private void OnDisable()
    {
        gunMaster.EventShotDefault -= ApplyForce;
    }

    void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
        myTransfrom = transform;
    }

    void ApplyForce(Vector3 hitPosition, Transform hitTransform)
    {
        if (hitTransform.GetComponent<Rigidbody>() != null) {
            hitTransform.GetComponent<Rigidbody>().AddForce(myTransfrom.forward * forceToApply, ForceMode.Impulse);

        }
    }
}
