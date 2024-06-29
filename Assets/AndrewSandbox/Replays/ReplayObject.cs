using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayObject : MonoBehaviour
{

    public PrototypeInteractionCollider interactTrigger;
    private PrototypeInteractable currentInteraction;
    private bool isReadyToInteract = false;

    public void SetDataForFrame(ReplayData data)
    {
        transform.position = data.position;
        transform.eulerAngles = data.rotation;
        InteractWith(data);
    }

    public void InteractWith(ReplayData data)
    {
        if (data.tryingToInteract)
        {
            // Debug.Log("Trying to interact");
            interactTrigger.interactJustPressed = true;
        }
        else
        {
            interactTrigger.interactJustPressed = false;
        }

    }


}
