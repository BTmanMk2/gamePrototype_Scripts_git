﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_Master : MonoBehaviour {

    public delegate void HealthEventHandler(int health);
    public event HealthEventHandler EventDeductHealth;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventDestroyMe;
    public event GeneralEventHandler EventHealthLow;

	public void CallEventDeductHealth(int healthToDeduct)
    {
        if (EventDeductHealth != null) {
            EventDeductHealth(healthToDeduct);
        }
    }

    public void CallEventDestroyMe()
    {
        if (EventDestroyMe != null) {
            EventDestroyMe();
        }
    }

    public void CallEventHealthLow()
    {
        if (EventHealthLow != null) {
            EventHealthLow();
        }
    }

}
