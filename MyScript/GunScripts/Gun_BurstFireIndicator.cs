using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_BurstFireIndicator : MonoBehaviour
{

    private Gun_Master gunMaster;
    public GameObject burstFireIndicator;

    // Use this for initialization
    void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventToggleBurstFire += ToggleIndicator;
    }

    private void OnDisable()
    {
        gunMaster.EventToggleBurstFire -= ToggleIndicator;
    }

    void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
    }

    void ToggleIndicator()
    {
        if (burstFireIndicator != null) {
            burstFireIndicator.SetActive(!burstFireIndicator.activeSelf);
        }
    }

}
