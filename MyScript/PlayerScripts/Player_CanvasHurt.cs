using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CanvasHurt : MonoBehaviour {

    public GameObject hurtCanvas;
    //private GameManager_Master gameManagerMaster;
    private Player_Master playerMaster;
    private float secondsTillHide = 2;

    private void OnEnable()
    {
        SetInitialReferences();
        playerMaster.EventPlayerHealthDeduction += TurnOnHurtEffect;
    }

    private void OnDisable()
    {
        playerMaster.EventPlayerHealthDeduction -= TurnOnHurtEffect;
    }

    void SetInitialReferences()
    {
        playerMaster = GetComponent<Player_Master>();
    }

    void TurnOnHurtEffect(int dummy)
    {
        if (hurtCanvas != null) {
            StopAllCoroutines();
            hurtCanvas.SetActive(true);
            StartCoroutine(ResetHurtCanvas());
        }
    }

    IEnumerator ResetHurtCanvas()
    {
        yield return new WaitForSeconds(secondsTillHide);
        hurtCanvas.SetActive(false);
    }
}
