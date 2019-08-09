using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            print("Ammo Picked Up!");
            other.GetComponent<Ammo>().IncreseAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
