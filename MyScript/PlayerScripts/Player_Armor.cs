using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Armor : MonoBehaviour {

    private GameManager_Master gameManagerMaster;
    private Player_Master playerMaster;

    public int playerCurrentArmor = 100;
    public int maxArmor = 200;
    public Text armorText;


    private void OnEnable()
    {
        SetInitialReferences();
        SetUI();
        playerMaster.EventPlayerArmorDeduction += DeductArmor;
        playerMaster.EventPlayerArmorIncrease += IncreaseArmor;
    }

    private void OnDisable()
    {
        playerMaster.EventPlayerArmorDeduction -= DeductArmor;
        playerMaster.EventPlayerArmorIncrease -= IncreaseArmor;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
        playerMaster = GetComponent<Player_Master>();
    }

    void DeductArmor(int armorChange)
    {
        playerCurrentArmor -= armorChange;
        if (playerCurrentArmor < 0) {
            playerCurrentArmor = 0;
        }
        SetUI();
    }

    void IncreaseArmor(int armorChange)
    {
        playerCurrentArmor += armorChange;
        if (playerCurrentArmor > maxArmor) {
            playerCurrentArmor = maxArmor;
        }
        SetUI();
    }

    void SetUI()
    {
        if (armorText != null) {
            armorText.text = playerCurrentArmor.ToString();

        }
    }
}
