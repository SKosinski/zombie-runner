using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            print("Ammo Picked Up!");
            other.GetComponentInChildren<FlashlightSystem>().RestoreLight();
            Destroy(gameObject);
        }
    }
}
