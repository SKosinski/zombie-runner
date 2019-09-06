using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas pauseCanvas;

    void Start()
    {
        gameOverCanvas.enabled = false;
        winCanvas.enabled = false;
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandlePause();
        }
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        StopGame();
    }

    public void HandleWin()
    {
        StartCoroutine(HandleWinCoroutine());
    }
    IEnumerator HandleWinCoroutine()
    {
        yield return new WaitForSeconds(3f);
        winCanvas.enabled = true;
        StopGame();
    }

    public void HandlePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseCanvas.enabled == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        pauseCanvas.enabled = true;
        StopGame();
    }

    public void ResumeGame()
    {
        pauseCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1;
        FindObjectOfType<WeaponSwitcher>().enabled = true;
        FindObjectOfType<WeaponZoom>().enabled = true;
        FindObjectOfType<Weapon>().enabled = true;
    }

    private void StopGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        FindObjectOfType<WeaponZoom>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false;
    }
}
