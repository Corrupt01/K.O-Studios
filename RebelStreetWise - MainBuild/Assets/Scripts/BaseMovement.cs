using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BaseMovement : MonoBehaviour
{
    public float moveSpeed = 3;
    public float jumpForce = 10.0f;
    public float gravity = 14.0f;
    public float verticalVelocity = -14.0f;
    public float dashDist = 3;
    public float dashSpeed = 6;
    //public float stopSpeed = .1f;
    
    
    private CharacterController character;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Walk();
        Jump();
    }

    public void Walk()
    {
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * moveSpeed;
        Vector2 movement = new Vector2(deltaX, deltaY);
        movement = Vector2.ClampMagnitude(movement, moveSpeed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        
        character.Move(movement);
		//Debug.Log (movement.x + " " + movement.y);
    }

    public void Dash(Vector2 direction)
    {
        direction = transform.forward * dashDist;
        character.Move(direction * Time.deltaTime * dashSpeed);
    }

    public void Jump()
    {
        bool jumped = false;
        

        if (character.isGrounded && !jumped)
        {
            Debug.Log("beans");
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Magic beans");
                verticalVelocity = jumpForce;
                jumped = true;
            }
        }
        else
        {
            Debug.Log("bad beans");
            verticalVelocity -= gravity * Time.deltaTime;
            jumped = false;
        }

        Debug.Log(character.isGrounded);
        Vector2 jump = new Vector2(0, verticalVelocity);
        character.Move(jump);
    }

    public void Duck()
    {

    }

    public void Block()
    {

    }
}
