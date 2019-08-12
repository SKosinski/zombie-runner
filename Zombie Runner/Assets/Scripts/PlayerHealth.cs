using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] Text healthText;
    [SerializeField] Canvas hitCanvas;

    void Start()
    {
        healthText.text = health.ToString();
        hitCanvas.enabled = false;
    }

    void Update()
    {
        
    }

    public void LoseHealth(int amount)
    {
        health -= amount;
        healthText.text = health.ToString();

        if (health<=0)
        {
            PlayerDeath();
        }
        else
        {
            StartCoroutine(hitCanvasRoutine());
        }
    }

    IEnumerator hitCanvasRoutine()
    {
        hitCanvas.enabled = true;
        hitCanvas.GetComponentInChildren<Image>().CrossFadeAlpha(0f, 0.3f, false);
        yield return new WaitForSeconds(0.3f);
        hitCanvas.enabled = false;
        hitCanvas.GetComponentInChildren<Image>().CrossFadeAlpha(1f, 0.001f, false);
    }

    private void PlayerDeath()
    {
        GetComponent<DeathHandler>().HandleDeath();
    }
}
