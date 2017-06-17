using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SetRotation : MonoBehaviour {

    private Item_Master itemMaster;
    public Vector3 itemLocalRotation;

    private void OnEnable()
    {
        SetInitialReferences();

        itemMaster.EventObjectPickup += SetRotationOnPlayer;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= SetRotationOnPlayer;
    }

    private void Start()
    {
        SetRotationOnPlayer();
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
    }

    void SetRotationOnPlayer()
    {
        if (transform.root.CompareTag(GameManager_References._playerTag)) {
            transform.localEulerAngles = itemLocalRotation;
        }
    }
}
