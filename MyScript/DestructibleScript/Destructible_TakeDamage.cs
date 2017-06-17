using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_TakeDamage : MonoBehaviour {

    private Destructible_Master destructibleMaster;

	// Use this for initialization
	void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetInitialReferences()
    {
        destructibleMaster = GetComponent<Destructible_Master>();
    }

    public void ProcessDamage(int damage)
    {
        destructibleMaster.CallEventDeductHealth(damage);
    }
}
