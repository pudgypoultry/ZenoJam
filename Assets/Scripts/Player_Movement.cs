using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] KeyCode up_input;
    [SerializeField] KeyCode down_input;
    [SerializeField] KeyCode left_input;
    [SerializeField] KeyCode right_input;
    [SerializeField] KeyCode interact_input;
    [SerializeField] float speed;
    [SerializeField] int animation_wait;

    Vector3 movement;
    bool moving = false;
    int frame;

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
        if (moving) {
            Animate();
        }
    }

    void CheckInput() {

        bool up = false, left = false;
        int num_keys = 0;

        if (Input.GetKey(up_input)) {
            up = true;
            
            movement.y = speed;
            num_keys++;
        }
        else if (Input.GetKey(down_input)) {
            if (!up) {
                movement.y = -speed;
            }
            else {
                movement.y = 0;
            }
            num_keys++;
        }
        else {
            movement.y = 0;
        }
        if (Input.GetKey(left_input)) {
            left = true;
            
            movement.x = -speed;
            num_keys++;
        }
        else if (Input.GetKey(right_input)) {
            if (!left) {
                movement.x = speed;
            }
            else {
                movement.x = 0;
            }
            num_keys++;
        }
        else {
            movement.x = 0;
        }

        if (num_keys == 0) {
            moving = false;
            frame = 0;
        }
        else if (num_keys > 1) {
            //  Divide to make movement smooth for diagonals
            movement.x /= 1.4f;
            movement.y /= 1.4f;
        }
    }

    void MovePlayer() {
        if (movement != Vector3.zero) {
            this.transform.position += movement;
            moving = true;
        }
    }

    void Animate() {
        if (frame == animation_wait) {
            this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
        }
        frame++;
        if (frame > animation_wait) {
                frame = 0;
            }
    }
}
