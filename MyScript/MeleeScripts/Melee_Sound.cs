using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Sound : MonoBehaviour {

    private Melee_Master meleeMaster;
    private Transform myTransform;
    public AudioClip swingSound;
    public AudioClip strikeSound;
    public float swingSoundVolume = 0.5f;
    public float strikeSoundVolume = 0.5f;

    private void OnEnable()
    {
        SetInitialReferences();
        meleeMaster.EventHit += PlayStrikeSound;
    }

    private void OnDisable()
    {
        meleeMaster.EventHit -= PlayStrikeSound;
    }

    void SetInitialReferences()
    {
        meleeMaster = GetComponent<Melee_Master>();
        myTransform = transform;
    }

    void PlaySwingSound()   //called by animation
    {
        if (swingSound != null) {
            AudioSource.PlayClipAtPoint(swingSound, myTransform.position, swingSoundVolume);
        }
    }

    void PlayStrikeSound(Collision dummyCol, Transform dummyTransform)
    {
        if (strikeSound != null) {
            AudioSource.PlayClipAtPoint(strikeSound, myTransform.position, strikeSoundVolume);
        }
    }
}
