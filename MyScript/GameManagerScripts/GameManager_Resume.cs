using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Resume : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.ResumeEvent += Resume;
    }

    private void OnDisable()
    {
        gameManagerMaster.ResumeEvent -= Resume;
    }


    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void Resume()
    {
        if (!gameManagerMaster.isGameOver) {
            if (gameManagerMaster.isInventoryUIOn) {
                GetComponent<GameManager_ToggleInventoryUI>().ToggleInventoryUI();
            }
            if (gameManagerMaster.isMenuOn) {
                GetComponent<GameManager_ToggleMenu>().ToggleMenu();
            }
        }
    }
}
