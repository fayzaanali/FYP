using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool isGrounded;
    private bool isWalking;
    public float speed = 5f;
    //public float sprint = 10f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        isWalking = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMovement(Vector2 input)
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        controller.Move(transform.TransformDirection(moveDir) * speed * Time.smoothDeltaTime);
        playerVelocity.y += gravity * Time.smoothDeltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.smoothDeltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded) 
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    //public void Sprint()
    //{
    //    float setSpeed;
    //    if(isWalking)
    //    {
    //        setSpeed = sprint;
    //    } else if (!isWalking)
    //    {
    //        setSpeed = speed;
    //    }
    //}

    public void Walk()
    {
        isWalking = false;
    }
}
