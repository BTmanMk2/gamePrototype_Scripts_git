using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_UI : MonoBehaviour {

    private Item_Master itemMaster;
    public GameObject myUI;
    public GameObject myCrosshair;

    private void OnEnable()
    {
        SetInitialReferences();
        itemMaster.EventObjectPickup += EnableMyUI;
        itemMaster.EventObjectThrow += DisableMyUI;

        itemMaster.EventObjectPickup += EnableMyCrosshair;
        itemMaster.EventObjectThrow += DisableMyCrosshair;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= EnableMyUI;
        itemMaster.EventObjectThrow -= DisableMyUI;

        itemMaster.EventObjectPickup -= EnableMyCrosshair;
        itemMaster.EventObjectThrow -= DisableMyCrosshair;
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
    }

    void EnableMyUI()
    {
        if (myUI != null) {
            myUI.SetActive(true);
        }
    }

    void DisableMyUI()
    {
        if (myUI != null) {
            myUI.SetActive(false);
        }
    }

    void EnableMyCrosshair()
    {
        if (myCrosshair != null) {
            myCrosshair.SetActive(true);
        }
    }

    void DisableMyCrosshair()
    {
        if (myCrosshair != null) {
            myCrosshair.SetActive(false);
        }
    }
}
