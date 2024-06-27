using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AndrewPlayerMovement : MonoBehaviour
{
    [SerializeField] KeyCode up_input;
    [SerializeField] KeyCode down_input;
    [SerializeField] KeyCode left_input;
    [SerializeField] KeyCode right_input;
    [SerializeField] KeyCode interact_input;
    [SerializeField] float speed;
    [SerializeField] int animation_wait;
    [SerializeField] PrototypeInteractionCollider interactionCollider;
    public bool isEcho = false;

    Vector3 movement;
    bool moving = false;
    int frame;

    private Recorder recorder;

    private void Awake()
    {
        recorder = GetComponent<Recorder>();
    }

    // Start is called before the first frame update
    void Start()
    {
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        MovePlayer();
        CheckForInteraction();
        if (moving)
        {
            // Animate();
        }
    }

    private void LateUpdate()
    {
        ReplayData data = new ReplayData(this.transform.position, this.transform.eulerAngles);
        recorder.RecordReplayFrame(data);
    }

    void CheckInput()
    {

        bool up = false, left = false;
        int num_keys = 0;

        if (Input.GetKey(up_input))
        {
            up = true;

            movement.z = 1;
            num_keys++;
        }
        else if (Input.GetKey(down_input))
        {
            if (!up)
            {
                movement.z = -1;
            }
            else
            {
                movement.z = 0;
            }
            num_keys++;
        }
        else
        {
            movement.z = 0;
        }

        if (Input.GetKey(left_input))
        {
            left = true;

            movement.x = -1;
        }
        else if (Input.GetKey(right_input))
        {
            if (!left)
            {
                movement.x = 1;
            }
            else
            {
                movement.x = 0;
            }
        }
        else
        {
            movement.x = 0;
        }

        if (num_keys == 0)
        {
            frame = 0;
        }
    }

    void MovePlayer()
    {
        if (movement != Vector3.zero)
        {
            this.transform.position += movement.normalized * speed * Time.deltaTime;
            moving = true;
            RotatePlayer(movement);
        }
    }

    void RotatePlayer(Vector3 movement)
    {
        transform.rotation = Quaternion.LookRotation(movement);
    }


    void CheckForInteraction()
    {
        if (Input.GetKeyDown(interact_input))
        {
            Debug.Log("Trying to interact");
            interactionCollider.interactJustPressed = true;
            interactionCollider.interactHeld = true;
        }
        else
        {
            interactionCollider.interactJustPressed = false;
        }

        if (Input.GetKeyUp(interact_input))
        {
            interactionCollider.interactHeld = false;
        }


    }



    void Animate()
    {
        if (frame == animation_wait)
        {
            this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
        }
        frame++;
        if (frame > animation_wait)
        {
            frame = 0;
        }
    }
}

