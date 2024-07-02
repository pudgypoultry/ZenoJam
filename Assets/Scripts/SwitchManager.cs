using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public GameObject doorSprite;
    public GameObject doorWall;

    private int activeSwitchCount = 0; 

    void Start()
    {
        doorSprite.SetActive(false); 
        doorWall.SetActive(true); 
    }

    public void ActivateSwitch()
    {
        activeSwitchCount++;
        CheckAllSwitches();
    }

    public void DeactivateSwitch()
    {
        activeSwitchCount--;
        CheckAllSwitches();
    }

    private void CheckAllSwitches()
    {
        if (activeSwitchCount == 3) 
        {
            doorSprite.SetActive(true);
            doorWall.SetActive(false); 

        }
        else
        {
            doorSprite.SetActive(false);
            doorWall.SetActive(true); 

        }
    }
}