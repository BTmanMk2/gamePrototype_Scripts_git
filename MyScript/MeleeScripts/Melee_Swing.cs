using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Swing : MonoBehaviour {

    private Melee_Master meleeMaster;
    public Collider myCollider;
    public Rigidbody myRigidbody;
    public Animator myAnimator;

    private void OnEnable()
    {
        SetInitialReferences();
        meleeMaster.EventPlayerInput += MeleeAttackActions;
    }

    private void OnDisable()
    {
        meleeMaster.EventPlayerInput -= MeleeAttackActions;
    }

    void SetInitialReferences()
    {
        meleeMaster = GetComponent<Melee_Master>();
    }

    void MeleeAttackActions()
    {
        myCollider.enabled = true;
        myRigidbody.isKinematic = false;
        myAnimator.SetTrigger("Attack");
    }

    void MeleeAttackComplete()  //called by animation
    {
        myCollider.enabled = false;
        myRigidbody.isKinematic = true;
        meleeMaster.isInUse = false;

    }
}
