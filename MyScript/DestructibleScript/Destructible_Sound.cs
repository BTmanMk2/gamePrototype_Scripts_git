using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_Sound : MonoBehaviour {

    private Destructible_Master destructibleMaster;
    public float explosionVolume = 0.5f;
    public AudioClip explodingSound;

    private void OnEnable()
    {
        SetInitialReferences();
        destructibleMaster.EventDestroyMe += PlayExplosionSound;
    }

    private void OnDisable()
    {
        destructibleMaster.EventDestroyMe -= PlayExplosionSound;
    }

    void SetInitialReferences()
    {
        destructibleMaster = GetComponent<Destructible_Master>();
    }

    void PlayExplosionSound()
    {
        if (explodingSound != null) {
            AudioSource.PlayClipAtPoint(explodingSound, transform.position, explosionVolume);
        }
    }
}
