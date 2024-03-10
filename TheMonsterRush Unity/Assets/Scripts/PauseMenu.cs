using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputAction pauseButton;
    [SerializeField] private Canvas canvas;

    private bool paused = false;

    private void OnEnable()
    {
        pauseButton.Enable();
    }

    private void OnDisable()
    {
        pauseButton.Disable();
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        canvas.enabled = false;
        pauseButton.performed += _ => Pause();        
    }

    private void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            canvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            canvas.enabled = false;
        }
    }
}