using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 10;

    public void TakeAHit(int shotPower)
    {
        BroadcastMessage("OnDamageTaken");
        enemyHealth -= shotPower;
        if (enemyHealth <= 0)
        {
            enemyDeath();
        }
    }

    private void enemyDeath()
    {
        Destroy(gameObject);
    }
}
