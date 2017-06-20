using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AmmoBox : MonoBehaviour {

    private Player_Master playerMaster;

    [System.Serializable]
    public class AmmoTypes
    {
        public string ammoName;
        public int ammoMaxQuantity;
        public int ammoCurrentCarried;

        public AmmoTypes(string aName, int aMaxQuantity, int aCurrentCarried)
        {
            ammoName = aName;
            ammoMaxQuantity = aMaxQuantity;
            ammoCurrentCarried = aCurrentCarried;
        }

    }

    public List<AmmoTypes> typesOfAmmunition = new List<AmmoTypes>();

    private void OnEnable()
    {
        SetInitialReferences();
        playerMaster.EventPickedUpAmmo += PickedUpAmmo;
    }

    private void OnDisable()
    {
        playerMaster.EventPickedUpAmmo -= PickedUpAmmo;
    }

    void SetInitialReferences()
    {
        playerMaster = GetComponent<Player_Master>();
    }

    void PickedUpAmmo(string ammoName,int quantity)
    {
        for(int i = 0; i < typesOfAmmunition.Count; i++) {
            if (typesOfAmmunition[i].ammoName.Equals(ammoName)) {
                typesOfAmmunition[i].ammoCurrentCarried += quantity;
                if (typesOfAmmunition[i].ammoCurrentCarried > typesOfAmmunition[i].ammoMaxQuantity) {
                    typesOfAmmunition[i].ammoCurrentCarried = typesOfAmmunition[i].ammoMaxQuantity;
                }

                playerMaster.CallEventAmmoChanged();
                break;
            }
        }
    }

    public int GetCarriedAmmo(string ammoName)
    {
        for (int i = 0; i < typesOfAmmunition.Count; i++) {
            if (typesOfAmmunition[i].ammoName.Equals(ammoName)) {
                return typesOfAmmunition[i].ammoCurrentCarried;
            }
        }
        return 0;
    }
}
