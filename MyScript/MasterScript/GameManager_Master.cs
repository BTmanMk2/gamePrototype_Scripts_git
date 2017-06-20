using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Master : MonoBehaviour {

    public delegate void GameManagerEventHandler();
    public event GameManagerEventHandler MenuToggleEvent;
    public event GameManagerEventHandler InventoryUIToggleEvent;
    public event GameManagerEventHandler RestartLevelEvent;
    public event GameManagerEventHandler GotoMenuSceneEvent;
    public event GameManagerEventHandler GameOverEvent;
    public event GameManagerEventHandler ExitEvent;
    public event GameManagerEventHandler ResumeEvent;

    public bool isGameOver;
    public bool isInventoryUIOn;
    public bool isMenuOn;

    public void CallEventMenuToggle()
    {
        if (MenuToggleEvent != null) {
            MenuToggleEvent();
        }
    }

    public void CallEventInventoryUIToggle()
    {
        if (InventoryUIToggleEvent != null) {
            InventoryUIToggleEvent();
        }
    }

    public void CallEventGameOver()
    {
        if (GameOverEvent != null) {
            isGameOver = true;
            GameOverEvent();
        }
    }

    public void CallEventRestartLevel()
    {
        if (RestartLevelEvent != null) {
            RestartLevelEvent();
        }
    }

    public void CallEventGotoMenuScene()
    {
        if (GotoMenuSceneEvent != null) {
            GotoMenuSceneEvent();
        }
    }


    public void CallEventExit()
    {
        if (ExitEvent != null) {
            ExitEvent();
        }
    }

    public void CallEventResume()
    {
        if (ResumeEvent != null) {
            ResumeEvent();
        }
    }


}
