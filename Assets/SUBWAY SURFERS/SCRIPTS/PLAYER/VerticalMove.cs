using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheckIfGrounded), typeof(Rigidbody))]

public class VerticalMove : MonoBehaviour
{

    [SerializeField] private float jumpForce=5f;

    private CheckIfGrounded groundCheck;
    private Rigidbody rigidBody;

    private void Start()
    {

        rigidBody= GetComponent<Rigidbody>();
        groundCheck= GetComponent<CheckIfGrounded>();

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

}
