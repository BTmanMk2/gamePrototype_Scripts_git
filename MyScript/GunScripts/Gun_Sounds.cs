﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Sounds : MonoBehaviour {

    private Gun_Master gunMaster;
    private Transform myTransform;
    public float shootVolume = 0.4f;
    public float reloadVolume = 0.5f;
    public AudioClip[] shootSound;
    public AudioClip reloadSound;

    private void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventPlayerInput += PlayShootSound;
    }

    private void OnDisable()
    {
        gunMaster.EventPlayerInput -= PlayShootSound;
    }

    void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
        myTransform = transform;
    }

    void PlayShootSound()
    {
        if (shootSound.Length > 0) {
            int index = Random.Range(0, shootSound.Length);
            AudioSource.PlayClipAtPoint(shootSound[index], myTransform.position, shootVolume);
        }
    }

    public void PlayReloadSound()   //called by the reload animation event
    {
        if (reloadSound != null) {
            AudioSource.PlayClipAtPoint(reloadSound, myTransform.position, reloadVolume);
        }
    }
}
