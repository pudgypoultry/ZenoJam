using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeInteractable : MonoBehaviour
{
    public string interactableName;
    public bool flag = false;

    public virtual void Interact()
    {
        Debug.Log("Interact function not implemented for this object");
    }

}
