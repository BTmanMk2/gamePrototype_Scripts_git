using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_PlayerInventoryUpdate : MonoBehaviour {

    private Destructible_Master destructibleMaster;
    private Player_Master playerMaster;

    private void OnEnable()
    {
        SetInitialReferences();
        destructibleMaster.EventDestroyMe += ForcePlayerInventoryUpdate;
    }

    private void OnDisable()
    {
        destructibleMaster.EventDestroyMe -= ForcePlayerInventoryUpdate;
    }

    // Use this for initialization
    void Start () {
        SetInitialReferences();
	}
	

    void SetInitialReferences()
    {
        if (GetComponent<Item_Master>() == null) {
            Destroy(this);
        }
        if (GameManager_References._player != null) {
            playerMaster = GameManager_References._player.GetComponent<Player_Master>();
        }

        destructibleMaster = GetComponent<Destructible_Master>();
    }

    void ForcePlayerInventoryUpdate()
    {
        if (playerMaster != null) {
            playerMaster.CallEventInventoryChanged();
        }
    }
}
