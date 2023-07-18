using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{

    [SerializeField, Range(-1, 1)] private int currentRail; //Es el carril donde se encuentra el jugador
    [SerializeField] private float horizontalSpeed; //Velocidad a la que nos moveremos horizontalmente
    [SerializeField] private float moveDistance; //Multiplicador de distancia de lado a lado
    

    // Update is called once per frame
    void Update()
    {

        RailSwitch();

    }

    private void RailSwitch()
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
