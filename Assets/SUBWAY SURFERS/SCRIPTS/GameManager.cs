using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    // Cuando presionas Start
    [SerializeField] private UnityEvent onGameStart;

    // Cuando reinicias el juego
    [SerializeField] private UnityEvent onGameRestart;

    // Cuando haces Game Over
    [SerializeField] private UnityEvent onGameOver;

    // Pausa
    [SerializeField] private UnityEvent onGamePause;

    #region Botones

    public void StartGame()
    {
        // El control del personaje se activa
        // El score por distancia se activa
        // Se desactiva el boton de start game en el ui
        // Se activa todo del ui
        // Se activa el spawn de obstaculos

        onGameStart.Invoke();
    }

    public void RestartGame()
    {
        // El control del personaje se activa
        // La posicion del personaje se reinicia
        // El score por distancia se vuelve 0 y se activa
        // Se desactiva el boton de start game en el ui
        // Se activa todo del ui

        onGameRestart.Invoke();
    }

    public void GameOver()
    {
        // Volver a prender el boton de inicio
        // Guardar el puntaje localmente
        // Desactivar todas las funciones del juego
        // Colocar al player en el punto de inicio
        // 2da Oportunidad

        onGameOver.Invoke();
    }

    public void PauseGame()
    {
        // Pausamos momentaneamente el score
        // Desactivamos los controles de movimiento
        // Desactivamos el spawn de obstaculos

        onGamePause.Invoke();
    }
    #endregion
}
