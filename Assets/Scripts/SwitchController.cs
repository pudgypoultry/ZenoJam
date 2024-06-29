using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Sprite switchOnSprite;
    public Sprite switchOffSprite;
    
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
            isSwitchOn = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSwitchOn = false;
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

