using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    float xMove, zMove;
    float yMove;
    public float speed;
    bool jump;
    public float jumpForce;

    public float gravity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        jump = Input.GetButton("Jump");
        yMove -= gravity * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(xMove, 0, zMove);
        move *= speed;
        animator.SetBool("Grounded", characterController.isGrounded);

        if (characterController.isGrounded)
        {
            if(jump)
            {
                yMove = jumpForce;
            }

            if (move.magnitude > float.Epsilon)
            {
                transform.rotation = Quaternion.LookRotation(move);
            }

        }
        animator.SetFloat("MoveSpeed", move.magnitude);

        move.y = yMove;

        characterController.Move(move * Time.fixedDeltaTime);
    }
}
