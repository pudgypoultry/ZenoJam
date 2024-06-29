using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayData
{
    public Vector3 position { get; private set; }
    public Vector3 rotation { get; private set; }
    public bool tryingToInteract { get; private set; }

    public ReplayData(Vector3 position, Vector3 rotation, bool tryingToInteract)
    {
        this.position = position;
        this.rotation = rotation;
        this.tryingToInteract = tryingToInteract;
    }
}
