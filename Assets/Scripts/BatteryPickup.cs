using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] AudioClip batteryPickUpSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            AudioSource.PlayClipAtPoint(batteryPickUpSFX, Camera.main.transform.position);
            other.GetComponentInChildren<FlashlightSystem>().RestoreLight();
            Destroy(gameObject);
        }
    }
}
