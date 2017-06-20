using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Health : MonoBehaviour {

    private Item_Master itemMaster;
    private GameObject playerGO;
    public int healthRecover;
    public bool isTriggerPickup;

    private void OnEnable()
    {
        SetInitialReferences();
        itemMaster.EventObjectPickup += RecoverHealth;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= RecoverHealth;
    }

    // Use this for initialization
    void Start()
    {
        SetInitialReferences();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameManager_References._playerTag) && isTriggerPickup) {
            RecoverHealth();
        }
    }

    void RecoverHealth()
    {
        if (playerGO.GetComponent<Player_Health>().playerHealth < playerGO.GetComponent<Player_Health>().maxHealth) {
            playerGO.GetComponent<Player_Master>().CallEventPlayerHealthIncrease(healthRecover);
            Destroy(gameObject);
        }
        
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
}
