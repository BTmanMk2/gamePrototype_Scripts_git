using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Transparency : MonoBehaviour {

    private Item_Master itemMaster;
    public Material transparentMat;
    private Material primaryMat;

	// Use this for initialization
	void Start () {
        CaptureStartingMaterial();
	}

    private void OnEnable()
    {
        SetInitialReferences();
        itemMaster.EventObjectPickup += SetToTransparentMaterial;
        itemMaster.EventObjectThrow += SetToPrimaryMaterial;
    }

    private void OnDisable()
    {
        itemMaster.EventObjectPickup -= SetToTransparentMaterial;
        itemMaster.EventObjectThrow -= SetToPrimaryMaterial;
    }

    void SetInitialReferences()
    {
        itemMaster = GetComponent<Item_Master>();
    }

    void CaptureStartingMaterial()
    {
        primaryMat = GetComponent<Renderer>().material;
    }

    void SetToPrimaryMaterial()
    {
        GetComponent<Renderer>().material = primaryMat;
    }

    void SetToTransparentMaterial()
    {
        GetComponent<Renderer>().material = transparentMat;
    }
}
