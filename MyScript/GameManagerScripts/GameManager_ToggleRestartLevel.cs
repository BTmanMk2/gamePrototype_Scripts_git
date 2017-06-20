using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_ToggleRestartLevel : MonoBehaviour {

    private GameManager_Master gameManagerMaster;

    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.RestartLevelEvent += RestartLevel;
    }

    private void OnDisable()
    {
        gameManagerMaster.RestartLevelEvent -= RestartLevel;
    }


    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(Application.loadedLevel);
    }
}
