using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypePlayerController : MonoBehaviour
{
    private bool isDead = false;

    [SerializeField]
    protected float playerSpeed = 2.25f;
    [SerializeField]
    protected float cameraSpeedX = 2f;
    [SerializeField]
    protected float cameraSpeedY = 2f;

    [SerializeField]
    protected float interactionRange = 5;

    protected float cameraY;
    protected float cameraX;
    protected Camera cam;

    protected Rigidbody rb;
    protected Vector3 moveDirection = Vector3.zero;

    public bool IsDead { get => isDead; set => isDead = value; }

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Vector3.zero;
        Movement();
        Rotation();
        Collectin();
    }

    protected virtual void Movement()
    {

        // Vector3 is a type, Vector3.zero = Vector3(0,0,0), think of this as (x, y, z)
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -1 * new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += new Vector3(cam.transform.right.x, 0, cam.transform.right.z).normalized;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -1 * new Vector3(cam.transform.right.x, 0, cam.transform.right.z).normalized;
        }

        moveDirection = moveDirection.normalized;
    }

    protected virtual void Rotation()
    {
        cameraX += cameraSpeedX * Input.GetAxis("Mouse X");
        cameraY -= cameraSpeedY * Input.GetAxis("Mouse Y");
        cameraY = Mathf.Clamp(cameraY, -80, 80);
        transform.eulerAngles = new Vector3(0.0f, cameraX, 0.0f);
        cam.transform.eulerAngles = new Vector3(cameraY, cameraX, 0.0f);
    }



    public virtual void Collectin()
    {
        Debug.DrawLine(transform.position, transform.position + (transform.forward * interactionRange), Color.red);
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Debug.Log("Collecting something");
            Ray collectRay = new Ray(cam.transform.position, cam.transform.forward);
            if (Physics.Raycast(collectRay, out hit))
            {
                Debug.Log("Attempting to collect: " + hit.transform.name);
            }

            if (Physics.Raycast(collectRay, out hit, interactionRange) && hit.transform.GetComponent<PrototypeInteractable>() != null)
            {
                Debug.Log("Attempting to collect: " + hit.transform.name);
                hit.transform.GetComponent<PrototypeInteractable>().Interact();
            }
        }
    }

    public virtual void KillMe()
    {
        Debug.Log("I'm dead");
    }

}
