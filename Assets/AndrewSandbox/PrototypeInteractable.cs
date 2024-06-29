using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeInteractable : MonoBehaviour
{
    public string interactableName;
    public bool flag = false;
    public bool hoveringOver = false;

    private PrototypeGameManager gameManager;

    private Material currentMaterial;
    private Material glowingMaterial;

    protected void Start()
    {
        gameManager = FindObjectOfType<PrototypeGameManager>().GetComponent<PrototypeGameManager>();
        currentMaterial = gameObject.GetComponent<Renderer>().material;
        glowingMaterial = gameManager.glowMaterial;

    }

    public virtual void Interact()
    {
        Debug.Log("Interact function not implemented for this object: " + this.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hoveringOver)
        {
            hoveringOver = true;
            // Debug.Log("Now hovering over: " + this.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hoveringOver)
        {
            hoveringOver = false;
            // Debug.Log("Done hovering over: " + this.name);
        }

    }
}
