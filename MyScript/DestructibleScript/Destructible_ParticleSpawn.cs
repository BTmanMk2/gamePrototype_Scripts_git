﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_ParticleSpawn : MonoBehaviour {

    private Destructible_Master destructibleMaster;
    public GameObject explosionEffect;

    private void OnEnable()
    {
        SetInitialReferences();
        destructibleMaster.EventDestroyMe += SpawnExplosion;
    }

    private void OnDisable()
    {
        destructibleMaster.EventDestroyMe -= SpawnExplosion;
    }

    void SetInitialReferences()
    {
        destructibleMaster = GetComponent<Destructible_Master>();
    }

    void SpawnExplosion()
    {
        if (explosionEffect != null) {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
    }
}
