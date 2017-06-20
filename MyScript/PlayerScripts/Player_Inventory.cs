using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Inventory : MonoBehaviour {

    public Transform inventoryPlayerParent;
    public Transform inventoryUIParent;
    public GameObject uiButton;

    public InputField pistolAmmo;
    public InputField ARAmmo;
    public InputField shotgunAmmo;

    private Player_Master playerMaster;
    private GameManager_Master gameManagerMaster;
    private GameManager_ToggleInventoryUI inventoryUIScript;
    private float timeToPlaceInHands = 0;
    private Transform currentlyHeldItem;
    private int counter;
    private string buttonText;
    private List<Transform> listInventory = new List<Transform>();

    private void OnEnable()
    {
        SetInitialReferences();
        UpdateInventoryListAndUI();
        CheckIfHandsEmpty();

        playerMaster.EventInventoryChanged += UpdateInventoryListAndUI;

        //playerMaster.EventInventoryChanged += CheckIfHandsEmpty;
        playerMaster.EventHandsEmpty += ClearHands;

        gameManagerMaster.InventoryUIToggleEvent += UpdateInventoryAmmo;
    }

    private void OnDisable()
    {
        playerMaster.EventInventoryChanged -= UpdateInventoryListAndUI;

        //playerMaster.EventInventoryChanged -= CheckIfHandsEmpty;
        playerMaster.EventHandsEmpty -= ClearHands;

        gameManagerMaster.InventoryUIToggleEvent -= UpdateInventoryAmmo;
    }

    void SetInitialReferences()
    {
        inventoryUIScript = GameObject.Find("GameManager").GetComponent<GameManager_ToggleInventoryUI>();
        gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
        playerMaster = GetComponent<Player_Master>();
    }

    void UpdateInventoryListAndUI()
    {
        counter = 0;
        listInventory.Clear();
        listInventory.TrimExcess();

        ClearInventoryUI();

        foreach(Transform child in inventoryPlayerParent) {
            if (child.CompareTag("Item")) {
                listInventory.Add(child);
                GameObject go = Instantiate(uiButton) as GameObject;
                buttonText = child.name;
                go.GetComponentInChildren<Text>().text = buttonText;
                go.GetComponentInChildren<Text>().fontSize = 38;
                int index = counter;
                go.GetComponent<Button>().onClick.AddListener(delegate { ActivateInventoryItem(index); });
                go.GetComponent<Button>().onClick.AddListener(inventoryUIScript.ToggleInventoryUI);
                go.transform.SetParent(inventoryUIParent, false);
                counter++;
            }
        }

        
    }

    void UpdateInventoryAmmo()
    {
        Player_AmmoBox ammoBox = GetComponent<Player_AmmoBox>();
        pistolAmmo.text = ammoBox.GetCarriedAmmo(pistolAmmo.name).ToString();
        ARAmmo.text = ammoBox.GetCarriedAmmo(ARAmmo.name).ToString();
        shotgunAmmo.text = ammoBox.GetCarriedAmmo(shotgunAmmo.name).ToString();
    }

    void CheckIfHandsEmpty()
    {
        if (currentlyHeldItem == null && listInventory.Count > 0) {
            StartCoroutine(PlaceItemInHands(listInventory[listInventory.Count - 1]));
        }
    }

    void ClearHands()
    {
        currentlyHeldItem = null;
    }

    void ClearInventoryUI()
    {
        foreach(Transform child in inventoryUIParent) {
            Destroy(child.gameObject);
        }
    }

    public void ActivateInventoryItem(int inventoryIndex)
    {
        DeactivateAllInventoryItems();
        StartCoroutine(PlaceItemInHands(listInventory[inventoryIndex]));
    }

    void DeactivateAllInventoryItems()
    {
        foreach(Transform child in inventoryPlayerParent) {
            if (child.CompareTag("Item")) {
                child.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator PlaceItemInHands(Transform itemTransform)
    {
        yield return new WaitForSeconds(timeToPlaceInHands);
        currentlyHeldItem = itemTransform;
        currentlyHeldItem.gameObject.SetActive(true);
    }
}
