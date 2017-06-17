using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_CollisionDetection : MonoBehaviour {

    private Destructible_Master destructibleMaster;
    private Collider[] hitColliders;
    private Rigidbody myRigidbody;
    public float thresholdMass = 50;
    public float thresholdSpeed = 6;

	// Use this for initialization
	void Start () {
        SetInitialReferences();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0) {
            if (collision.contacts[0].otherCollider.GetComponent<Rigidbody>() != null) {
                CollisionCheck(collision.contacts[0].otherCollider.GetComponent<Rigidbody>());
            }else {
                SelfSpeedCheck();
            }
            
        }
    }

    void SetInitialReferences()
    {
        destructibleMaster = GetComponent<Destructible_Master>();
        if (GetComponent<Rigidbody>() != null) {
            myRigidbody = GetComponent<Rigidbody>();
        }
    }

    void CollisionCheck(Rigidbody otherRigidbody)
    {
        if(otherRigidbody.mass>thresholdMass
            && otherRigidbody.velocity.sqrMagnitude > (thresholdSpeed * thresholdSpeed)) {
            int damage = (int)otherRigidbody.mass;
            destructibleMaster.CallEventDeductHealth(damage);
        }else {
            SelfSpeedCheck();
        }

    }

    void SelfSpeedCheck()
    {
        if (myRigidbody.velocity.sqrMagnitude > thresholdSpeed * thresholdSpeed) {
            int damage = (int)myRigidbody.mass;
            destructibleMaster.CallEventDeductHealth(damage);
        }
    }
}
