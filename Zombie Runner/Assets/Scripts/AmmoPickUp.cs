using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioClip ammoPickUpSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            AudioSource.PlayClipAtPoint(ammoPickUpSFX, Camera.main.transform.position);
            other.GetComponent<Ammo>().IncreseAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
