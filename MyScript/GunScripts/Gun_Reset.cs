using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Reset : MonoBehaviour {

    private Gun_Master gunMaster;
    private Item_Master itemMaster;

    private void OnEnable()
    {
        SetInitialReferences();
        if (itemMaster != null) {
            itemMaster.EventObjectThrow += ResetGun;
        }
    }

    private void OnDisable()
    {
        itemMaster.EventObjectThrow -= ResetGun;
    }

    void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
        if (GetComponent<Item_Master>() != null) {
            itemMaster = GetComponent<Item_Master>();
        }
    }

    void ResetGun()
    {
        gunMaster.CallEventRequestGunReset();
    }
}
