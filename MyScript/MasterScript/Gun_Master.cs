using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Master : MonoBehaviour {

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventPlayerInput;
    public event GeneralEventHandler EventGunNotUsable;
    public event GeneralEventHandler EventRequestReload;
    public event GeneralEventHandler EventRequestGunReset;
    public event GeneralEventHandler EventToggleBurstFire;
    //public event GeneralEventHandler Event

    public delegate void GunHitEventHandler(Vector3 hitPosition, Transform hitTransform, RaycastHit hit);
    public event GunHitEventHandler EventShotDefault;
    public event GunHitEventHandler EventShotEnemy;

    public delegate void GunAmmoEventHandler(int currentAmmo, int carriedAmmo);
    public event GunAmmoEventHandler EventAmmoChanged;

    public delegate void GunCrosshairEventHandler(float speed);
    public event GunCrosshairEventHandler EventSpeedCaptured;

    public Transform magazineTransform;
    public Transform boltTransform;

    private Vector3 startMagTransformLocalPos;
    private Quaternion startMagTransformLocalRot;

    private Vector3 startBoltTransformLocalPos;
    private Quaternion startBoltTransformLocalRot;

    public bool isGunLoaded;
    public bool isReloading;

    private void OnEnable()
    {
        if (magazineTransform != null) {
            startMagTransformLocalPos = new Vector3(magazineTransform.localPosition.x, magazineTransform.localPosition.y, magazineTransform.localPosition.z);
            startMagTransformLocalRot = new Quaternion(magazineTransform.localRotation.x,
                magazineTransform.localRotation.y,
                magazineTransform.localRotation.z,
                magazineTransform.localRotation.w);
        }

        if (boltTransform != null) {
            startBoltTransformLocalPos = new Vector3(boltTransform.localPosition.x, boltTransform.localPosition.y, boltTransform.localPosition.z);
            startBoltTransformLocalRot = new Quaternion(boltTransform.localRotation.x,
                boltTransform.localRotation.y,
                boltTransform.localRotation.z,
                boltTransform.localRotation.w);
        }
        
    }

    public Vector3 getMagazineLocalPos()
    {
        return startMagTransformLocalPos;
    }

    public Quaternion getMagazineLocalRot()
    {
        return startMagTransformLocalRot;
    }

    public Vector3 getBoltLocalPos()
    {
        return startBoltTransformLocalPos;
    }

    public Quaternion getBoltLocalRot()
    {
        return startBoltTransformLocalRot;
    }

    public void CallEventPlayerInput()
    {
        if (EventPlayerInput != null) {
            EventPlayerInput();
        }
    }

    public void CallEventGunNotUsable()
    {
        if (EventGunNotUsable != null) {
            EventGunNotUsable();
        }
    }

    public void CallEventRequestReload()
    {
        if (EventRequestReload != null) {
            EventRequestReload();
        }
    }

    public void CallEventRequestGunReset()
    {
        if (EventRequestGunReset != null) {
            EventRequestGunReset();
        }
    }

    public void CallEventToggleBurstFire()
    {
        if (EventToggleBurstFire != null) {
            EventToggleBurstFire();
        }
    }

    public void CallEventShotDefault(Vector3 hPos, Transform hTransform, RaycastHit hit)
    {
        if (EventShotDefault != null) {
            EventShotDefault(hPos, hTransform, hit);
        }
    }

    public void CallEventShotEnemy(Vector3 hPos, Transform hTransform, RaycastHit hit)
    {
        if (EventShotEnemy != null) {
            EventShotEnemy(hPos, hTransform, hit);
        }
    }

    public void CallEventAmmoChanged(int curAmmo,int carAmmo)
    {
        if (EventAmmoChanged != null) {
            EventAmmoChanged(curAmmo, carAmmo);
        }
    }

    public void CallEventSpeedCaptured(float spd)
    {
        if (EventSpeedCaptured != null) {
            EventSpeedCaptured(spd);
        }
    }

}
