using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayObject : MonoBehaviour
{
    public void SetDataForFrame(ReplayData data)
    {
        transform.position = data.position;
        transform.eulerAngles = data.rotation;
    }
}
