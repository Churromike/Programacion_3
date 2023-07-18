    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheckIfGrounded), typeof(Rigidbody))]

public class VerticalMove : MonoBehaviour
{

    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float downForce = 12;

    [SerializeField] private float jumpBoost = 2;
    [SerializeField] private bool isBuffActive = false;

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
        Roll();
    }

    private void JumpControl()
    {
        if (JumpInput() && groundCheck.IsGrounded)
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

    private float JumpForce()
    {
        return isBuffActive ? (jumpForce * jumpBoost) : jumpForce;
    }

    public void ActiveJumpBuff(bool value)
    {
        isBuffActive = value;
    }


    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        isBuffActive = false;
    }

    public void EnableScript()
    {
        enabled = true;
    }

    public void DisableScript()
    {
        enabled = false;
    }

}
