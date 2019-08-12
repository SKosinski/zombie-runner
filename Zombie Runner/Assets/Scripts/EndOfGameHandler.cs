using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGameHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas winCanvas;

    void Start()
    {
        gameOverCanvas.enabled = false;
        winCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false;
    }

    public void HandleWin()
    {
        StartCoroutine(HandleWinCoroutine());
    }

    IEnumerator HandleWinCoroutine()
    {
        yield return new WaitForSeconds(3f);
        winCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        FindObjectOfType<Weapon>().enabled = false;
    }
}
