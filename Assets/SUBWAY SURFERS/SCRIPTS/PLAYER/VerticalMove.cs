using System;
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

    private Vector2 startInputPosition; // Aqui se guarda en que parte de la pantalla se empezo a tocar
    private Vector2 endInputPosition; // Aqui se guarda en que parte de la pantalla se despego el dedo

    private Action VerticalMoveController;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        groundCheck = GetComponent<CheckIfGrounded>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        VerticalMoveController();
    }

    private void VerticalMoveWithKeys()// Este metodo va a ser el como se realiza el salto desde computadora
    {
        if (JumpInput() && groundCheck.IsGrounded)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (RollInput() && groundCheck.IsGrounded)
        {
            anim.Play("Roll");
        }
        else if (RollInput() && !groundCheck.IsGrounded)
        {
            rigidBody.AddForce(Vector3.down * downForce, ForceMode.Impulse);
            anim.Play("Roll");
        }      

    }

    private void VerticalMoveWithTouch()
    {

        if ((TouchInputSwipe() > 0) && groundCheck.IsGrounded)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if ((TouchInputSwipe() < 0) && groundCheck.IsGrounded)
        {
            anim.Play("Roll");
        }
        else if ((TouchInputSwipe() < 0) && !groundCheck.IsGrounded)
        {
            rigidBody.AddForce(Vector3.down * downForce, ForceMode.Impulse);
            anim.Play("Roll");
        }
    }

    private void JumpControlWithKeys() // Este metodo va a ser el como se realiza el salto desde computadora
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
        else if (RollInput() && !groundCheck.IsGrounded)
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

    private int TouchInputSwipe()
    {
        if (InputTouchBegan()) // Si ya empece a tocar el celular entonces
        {
            startInputPosition = InputPosition(); // Voy a guardar mi posicion del input inicial
        }

        if (InputTouchEnded())
        {
            endInputPosition = InputPosition();

            if (endInputPosition.y > startInputPosition.y) //  Si la posicion donde termine de tocar es mayor que donde empece a tocar entonces
            {
                return 1; // me dice que deslice hacia arriba
            }
            else if (endInputPosition.y < startInputPosition.y) // Si la posicion donde termine de tocar es menor que donde empece a tocar entonces
            {
                return -1; // me dice que deslice hacia abajo
            }
        }
        return 0;
    }

    private Vector2 InputPosition() // Nos regresa donde esta el dedo en la pantalla
    {
        return Input.GetTouch(0).position;
    }

    private bool InputTouchEnded() // Cuando se deja de tocar la pantalla
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
    }

    private bool InputTouchBegan() // Nos regresa si se esta tocando la pantalla
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }

    public void ActiveJumpBuff(bool value)
    {
        isBuffActive = value;
    }

    public void PhoneConfig()
    {
        VerticalMoveController = VerticalMoveWithTouch;
    }

    /// <summary>
    /// Cambia los controles del movimiento horizontal para que funcionen por medio
    /// de teclas
    /// 
    /// **Este metodo se manda a llamar en el Eveneto ComputerConfig del GameManager
    /// </summary>
    public void ComputerConfig()
    {
        VerticalMoveController = VerticalMoveWithKeys;
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
