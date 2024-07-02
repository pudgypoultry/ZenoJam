using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Sprite switchOnSprite;
    public Sprite switchOffSprite;
    public SwitchManager switchManager; // Reference to the SwitchManager

    private bool isSwitchOn = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            if (!isSwitchOn)
            {
                isSwitchOn = true;
                switchManager.ActivateSwitch();
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            if (isSwitchOn)
            {
                isSwitchOn = false;
                switchManager.DeactivateSwitch();
            }
        }
    }

    void Update()
    {
        if (isSwitchOn)
        {
            spriteRenderer.sprite = switchOnSprite;
        }
        else
        {
            spriteRenderer.sprite = switchOffSprite;
        }
    }
}

