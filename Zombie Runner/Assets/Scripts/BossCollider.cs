using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    [SerializeField] GameObject boss;
    private void Start()
    {
        boss.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>())
        {
            boss.SetActive(true);
        }
    }
}
