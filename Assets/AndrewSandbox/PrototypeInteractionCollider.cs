using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeInteractionCollider : MonoBehaviour
{

    public bool interactJustPressed = false;
    public bool interactHeld = false;
    public bool interactionAvailable = false;
    public bool currentlyInteracting = false;
    public GameObject interactionCandidate;

    private void Update()
    {
        if (interactJustPressed && interactionCandidate != null)
        {
            interactionCandidate.GetComponent<PrototypeInteractable>().Interact();
            Debug.Log(transform.parent.name + " is trying to interact!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interactionAvailable = true;   
        interactionCandidate = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        interactionCandidate = null;
    }

}
