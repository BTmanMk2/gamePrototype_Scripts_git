using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Armor : MonoBehaviour {

    private Item_Master itemMaster;
    private GameObject playerGO;
    public int armorRecover;
    public bool isTriggerPickup;

    private void OnEnable()
    {
        SetInitialReferences();
        itemMaster.EventObjectPickup += RecoverArmor;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= RecoverArmor;
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
        playerGO = GameManager_References._player;

        if (isTriggerPickup) {
            if (GetComponent<SphereCollider>() != null) {
                GetComponent<SphereCollider>().isTrigger = true;
            }
            if (GetComponent<Rigidbody>() != null) {
                //GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    // Use this for initialization
    void Start () {
        SetInitialReferences();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameManager_References._playerTag) && isTriggerPickup) {
            RecoverArmor();
        }
    }

    void RecoverArmor()
    {
        if (playerGO.GetComponent<Player_Armor>().playerCurrentArmor < playerGO.GetComponent<Player_Armor>().maxArmor) {
            playerGO.GetComponent<Player_Master>().CallEventPlayerArmorIncrease(armorRecover);
            Destroy(gameObject);
        }
    }
}
