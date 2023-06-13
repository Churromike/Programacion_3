using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfGrounded : MonoBehaviour
{

    [SerializeField] private string groundTag;
    [SerializeField] private bool _isGrounded = true;

    public bool IsGrounded
    {

        get => _isGrounded;
        private set => _isGrounded = value;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == groundTag)
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == groundTag)
        {
            IsGrounded = false;
        }
    }

}
