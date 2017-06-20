using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleGameOver : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    public GameObject gameOverCanvas;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.GameOverEvent += ToggleGameOverCanvas;
    }

    private void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= ToggleGameOverCanvas;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void ToggleGameOverCanvas()
    {
        if (gameOverCanvas != null) {
            gameOverCanvas.SetActive(!gameOverCanvas.activeSelf);
        }
        else {
            Debug.LogWarning("No GameOver canvas attached");
        }

    }
}
