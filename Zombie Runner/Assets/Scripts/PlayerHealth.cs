using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(int amount)
    {
        health -= amount;

        if (health<=0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        GetComponent<DeathHandler>().HandleDeath();
    }
}
