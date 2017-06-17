using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Strike : MonoBehaviour {

    private Melee_Master meleeMaster;
    private float nextSwingTime;
    public float damage = 40;

    private void Start()
    {
        SetInitialReferences();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject!=GameManager_References._player&&
            meleeMaster.isInUse && Time.time > nextSwingTime) {
            nextSwingTime = Time.time + meleeMaster.swingRate;
            collision.transform.SendMessage("ProcessDamage", damage, SendMessageOptions.DontRequireReceiver);
            meleeMaster.CallEventHit(collision, collision.transform);
        }
    }

    void SetInitialReferences()
    {
        meleeMaster = GetComponent<Melee_Master>();
    }



}
