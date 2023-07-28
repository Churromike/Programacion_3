using System;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{

    [SerializeField] private DeviceEnum device;

    [Header("Movement")]
    [SerializeField, Range(-1, 1)] private int currentRail; //Es el carril donde se encuentra el jugador
    [SerializeField] private float horizontalSpeed; //Velocidad a la que nos moveremos horizontalmente
    [SerializeField] private float moveDistance; //Multiplicador de distancia de lado a lado

    private Vector2 startInputPosition; // Aqui se guarda en que parte de la pantalla se empezo a tocar
    private Vector2 endInputPosition; // Aqui se guarda en que parte de la pantalla se despego el dedo

    private Action RailSwitch;

    private void Start()
    {
        switch (device)
        {
            case DeviceEnum.Computadora:
                {
                    RailSwitch = RailSwitchWithKeys;
                    break;
                }

            case DeviceEnum.Celular:
                {
                    RailSwitch = RailSwitchWithTouch;
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {

        RailSwitch();

    }

    private void RailSwitchWithKeys()
    {

        transform.position = (Vector3)Vector2.MoveTowards(current: (Vector2)transform.position, TargetRail(), maxDistanceDelta: horizontalSpeed * Time.deltaTime); //Es lo que nos va a mover al jugador

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) //Movimiento hacia la izquierda
        {
            if (currentRail > -1)
            {
                currentRail--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) //Movimiento hacia la derecha
        {

            if (currentRail < 1)
            {
                currentRail++;
            }
        }

    }

    private void RailSwitchWithTouch()
    {

        transform.position = (Vector3)Vector2.MoveTowards(current: (Vector2)transform.position, TargetRail(), maxDistanceDelta: horizontalSpeed * Time.deltaTime); //Es lo que nos va a mover al jugador

        if (TouchInputSwipe() > 0) //Movimiento hacia la derecha
        {
            if (currentRail < 1)
            {
                currentRail++;
            }
        }
        else if (TouchInputSwipe() < 0) //Movimiento hacia la izquierda
        {

            if (currentRail > -1)
            {
                currentRail--;
            }
        }

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

            if (endInputPosition.x > startInputPosition.x) //  Si la posicion donde termine de tocar es mayor que donde empece a tocar entonces
            {
                return 1; // me muevo a la derecha
            }
            else if (endInputPosition.x < startInputPosition.x) // Si la posicion donde termine de tocar es menor que donde empece a tocar entonces
            {
                return -1; // me muevo a la izquierda
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

    private Vector2 TargetRail() //Indica el rail al que nos queremos mover
    {

        return new Vector2(x: currentRail * moveDistance, transform.position.y);

    }

    private void OnEnable()
    {
        currentRail = 0;
    }

    private void OnDisable()
    {

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
