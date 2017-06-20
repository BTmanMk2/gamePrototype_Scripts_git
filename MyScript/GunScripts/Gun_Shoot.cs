using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Shoot : MonoBehaviour {

    private Gun_Master gunMaster;
    private Transform myTransform;
    private Transform camTransform;
    private RaycastHit hit;
    public float range = 400;
    public float offsetFactor = 9;
    public float basicAccuracyFactor = 0;
    public int shells = 1;
    private Vector3 startPosition;

    private float speed;
    public float spreadFactor = 50;
    public float speedFactor = 1;

    private void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventPlayerInput += OpenFire;
        gunMaster.EventSpeedCaptured += SetStartOfShootingPosition;
    }

    private void OnDisable()
    {
        gunMaster.EventPlayerInput -= OpenFire;
        gunMaster.EventSpeedCaptured -= SetStartOfShootingPosition;
    }

    void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
        myTransform = transform;
        camTransform = myTransform.parent;
    }

    void OpenFire()
    {
        for(int i = 0; i < shells; i++) {
            Vector3 randomForward = camTransform.forward;
            float tempSpreadRange = (basicAccuracyFactor + (speed / speedFactor)) / spreadFactor;
            randomForward.x += Random.Range(-tempSpreadRange, tempSpreadRange);
            randomForward.y += Random.Range(-tempSpreadRange, tempSpreadRange);
            randomForward.z += Random.Range(-tempSpreadRange, tempSpreadRange);
            if (Physics.Raycast(camTransform.TransformPoint(startPosition), randomForward, out hit, range)) {
                
                if (hit.transform.CompareTag(GameManager_References._enemyTag)) {
                    //Debug.Log("Shoot enemy");
                    gunMaster.CallEventShotEnemy(hit.point, hit.transform, hit);
                }else{
                    
                    gunMaster.CallEventShotDefault(hit.point, hit.transform, hit);
                }
            }
        }
        
    }

    void SetStartOfShootingPosition(float playerSpeed)
    {
        speed = playerSpeed;
        //float offset = playerSpeed / offsetFactor;
        //startPosition = new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), 1);
        startPosition = new Vector3(0, 0, 0.5f);
    }


}
