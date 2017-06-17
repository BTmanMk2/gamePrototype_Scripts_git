using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_Degenerate : MonoBehaviour {

    private Destructible_Master destructibleMaster;
    private bool isHealthLow;
    private float degenRate = 1;
    private float nextDegenTime;
    public int healthLoss = 5;

    private void OnEnable()
    {
        SetInitialReferences();
        destructibleMaster.EventHealthLow += HealthLow;
    }

    private void OnDisable()
    {
        destructibleMaster.EventHealthLow -= HealthLow;
    }

    void SetInitialReferences()
    {
        destructibleMaster = GetComponent<Destructible_Master>();

    }

    private void Update()
    {
        CheckIfHealthShouldDegenerate();
    }

    void HealthLow()
    {
        isHealthLow = true;
    }

    void CheckIfHealthShouldDegenerate()
    {
        if (isHealthLow) {
            if (Time.time > nextDegenTime) {
                nextDegenTime = Time.time + degenRate;
                destructibleMaster.CallEventDeductHealth(healthLoss);
            }
        }
    }
}
