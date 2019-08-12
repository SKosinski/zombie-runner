using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 10;
    bool isDead = false;

    public void TakeAHit(int shotPower)
    {
        if (!isDead)
        {
            BroadcastMessage("OnDamageTaken");
            enemyHealth -= shotPower;
            if (enemyHealth <= 0)
            {
                enemyDeath();
            }
        }
    }

    private void enemyDeath()
    {
        GetComponent<Animator>().SetTrigger("die");
        DisableMovement();
        if (gameObject.tag == "Boss")
        {
            FindObjectOfType<EndOfGameHandler>().HandleWin();
        }
    }

    private void DisableMovement()
    {
        isDead = true;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<EnemyHealth>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
