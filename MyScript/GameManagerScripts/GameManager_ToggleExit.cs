using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleExit : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.ExitEvent += ExitGame;
    }

    private void OnDisable()
    {
        gameManagerMaster.ExitEvent -= ExitGame;
    }


    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
