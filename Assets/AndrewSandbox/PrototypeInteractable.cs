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

    public virtual void InteractToggle()
    {
        Debug.Log("InteractToggle function not implemented for this object: " + this.name);
    }

    public virtual void InteractHold()
    {
        Debug.Log("InteractHold function not implemented for this object: " + this.name);
    }

    public virtual void OnHover()
    {
        hoveringOver = true;
        gameObject.GetComponent<Renderer>().material = glowingMaterial;
    }

    public virtual void OffHover()
    {
        hoveringOver = false;
        gameObject.GetComponent<Renderer>().material = currentMaterial;
    }

}
