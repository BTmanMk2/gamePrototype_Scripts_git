﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_Health : MonoBehaviour {

    private Destructible_Master destructibleMaster;
    public int health;
    private int startingHealth;
    private bool isExploding = false;

    private void OnEnable()
    {
        SetInitialReferences();
        destructibleMaster.EventDeductHealth += DeductHealth;
    }

    private void OnDisable()
    {
        destructibleMaster.EventDeductHealth -= DeductHealth;
    }

    void SetInitialReferences()
    {
        destructibleMaster = GetComponent<Destructible_Master>();
        startingHealth = health;
    }

    void DeductHealth(int healthToDeduct)
    {
        health -= healthToDeduct;
        if (health < 0) {
            health = 0;
        }
        CheckIfHealthLow();
        if (!isExploding && health == 0) {
            isExploding = true;
            destructibleMaster.CallEventDestroyMe();
        }
    }

    void CheckIfHealthLow()
    {
        if (health <= startingHealth / 2) {
            destructibleMaster.CallEventHealthLow();
        }
    }
}
