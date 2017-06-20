using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Master : MonoBehaviour {

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventHandsEmpty;
    public event GeneralEventHandler EventInventoryChanged;
    public event GeneralEventHandler EventAmmoChanged;

    public delegate void AmmoPickupEventHandler(string ammoName, int quantity);
    public event AmmoPickupEventHandler  EventPickedUpAmmo;

    public delegate void PlayerHealthEventHandler(int healthChange);
    public event PlayerHealthEventHandler EventPlayerHealthDeduction;
    public event PlayerHealthEventHandler EventPlayerHealthIncrease;

    public delegate void PlayerArmorEventHandler(int armorChange);
    public event PlayerArmorEventHandler EventPlayerArmorDeduction;
    public event PlayerArmorEventHandler EventPlayerArmorIncrease;


    public void CallEventInventoryChanged()
    {
        if (EventInventoryChanged != null) {
            EventInventoryChanged();
        }
    }

    public void CallEventAmmoChanged()
    {
        if (EventAmmoChanged != null) {
            EventAmmoChanged();
        }
    }

    public void CallEventHandsEmpty()
    {
        if (EventHandsEmpty != null) {
            EventHandsEmpty();
        }
    }

    public void CallEventPlayerHealthDeduction(int dmg)
    {
        if (EventPlayerHealthDeduction != null) {
            EventPlayerHealthDeduction(dmg);
        }
    }

    public void CallEventPickUpAmmo(string ammoName, int quantity)
    {
        if (EventPickedUpAmmo != null) {
            EventPickedUpAmmo(ammoName, quantity);
        }
    }

    public void CallEventPlayerHealthIncrease(int increase)
    {
        if (EventPlayerHealthIncrease != null) {
            EventPlayerHealthIncrease(increase);
        }
    }

    public void CallEventPlayerArmorIncrease(int increase)
    {
        if (EventPlayerArmorIncrease != null) {
            EventPlayerArmorIncrease(increase);
        }
    }

    public void CallEventPlayerArmorDeduction(int dmg)
    {
        if (EventPlayerArmorDeduction != null) {
            EventPlayerArmorDeduction(dmg);
        }
    }
}
