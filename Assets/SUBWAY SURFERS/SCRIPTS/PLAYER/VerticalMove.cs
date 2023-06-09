using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheckIfGrounded), typeof(Rigidbody))]

public class VerticalMove : MonoBehaviour
{

    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float downForce = 12;

    private CheckIfGrounded groundCheck;
    private Rigidbody rigidBody;
    private Animator anim;

    private void Start()
    {

        rigidBody = GetComponent<Rigidbody>();
        groundCheck = GetComponent<CheckIfGrounded>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {

        JumpControl();

    }

    private void JumpControl()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && groundCheck.IsGrounded)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Roll()
    {
        if (RollInput() && groundCheck.IsGrounded)
        {
            anim.Play("Roll");
        }
        else if(RollInput() && !groundCheck.IsGrounded)
        {
            rigidBody.AddForce(Vector3.down * downForce, ForceMode.Impulse);
            anim.Play("Roll");
        }
    }

    private bool RollInput()
    {
        return Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
    }

    private bool JumpInput()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
    }

}
