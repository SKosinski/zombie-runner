using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 10;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    bool isDead = false;

    public void TakeAHit(int shotPower)
    {
        if (!isDead)
        {
            GetComponent<AudioSource>().PlayOneShot(enemyHitSFX);
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
        GetComponent<AudioSource>().PlayOneShot(enemyDeathSFX);
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
