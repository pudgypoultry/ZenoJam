using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHandler : MonoBehaviour
{

    public Dictionary<string, bool> resetFlags = new Dictionary<string, bool>();
    public GameObject gameManager;



    public void SetResetFlags(Dictionary<string, bool> settingFlags)
    {
        foreach (KeyValuePair<string, bool> kvp in settingFlags)
        {
            resetFlags[kvp.Key] = kvp.Value;
        }
    }

    public void GetResetFlags(Dictionary<string, bool> flagsToSet)
    {
        foreach (KeyValuePair<string, bool> kvp in resetFlags)
        {
            flagsToSet[kvp.Key] = kvp.Value;
        }
    }

    public bool GetFlag(string flagName)
    {
        if (resetFlags.ContainsKey(flagName))
        {
            return resetFlags[flagName];
        }
        Debug.Log("Flag not found in dictionary");
        return false;
    }
}
