using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleMenu : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    public GameObject menu;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckForMenuToggleRequest();
    }

    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.GameOverEvent += ToggleMenu;
    }

    private void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= ToggleMenu;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void CheckForMenuToggleRequest()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!gameManagerMaster.isGameOver
            && !gameManagerMaster.isInventoryUIOn) {
                ToggleMenu();
            }
            else {
                if (!gameManagerMaster.isGameOver
                && gameManagerMaster.isInventoryUIOn) {
                    GetComponent<GameManager_ToggleInventoryUI>().ToggleInventoryUI();
                }
            }
        }
    }

    public void ToggleMenu()
    {
        if (menu != null) {
            menu.SetActive(!menu.activeSelf);
            gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
            gameManagerMaster.CallEventMenuToggle();
        }
        else {
            Debug.LogWarning("No menu attached");
        }

    }
}
