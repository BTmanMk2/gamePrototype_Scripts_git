using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Master : MonoBehaviour {

    private Player_Master playerMaster;
    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventObjectThrow;
    public event GeneralEventHandler EventObjectPickup;

    public delegate void PickupActionEventHandler(Transform item);
    public event PickupActionEventHandler EventPickupAction;

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        SetInitialReferences();
    }

    public void CallEventObjectThrow()
    {
        if (EventObjectThrow != null) {
            EventObjectThrow();

        }
        if (playerMaster != null) {
            playerMaster.CallEventHandsEmpty();
            playerMaster.CallEventInventoryChanged();
        }
        
    }

    public void CallEventObjectPickup()
    {
        if (EventObjectPickup != null) {
            EventObjectPickup();
        }
        playerMaster.CallEventInventoryChanged();
    }

    public void CallEventPickupAction(Transform item)
    {
        if (EventPickupAction != null) {
            EventPickupAction(item);
        }
    }

    private void OnDisable()
    {

    }

    void SetInitialReferences()
    {
        if (GameManager_References._player != null) {
            playerMaster = GameManager_References._player.GetComponent<Player_Master>();
        }
    }
}
