using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int shotPower = 1;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] public bool canShoot = true;
    [SerializeField] float timeBetweenShots = 0;
    [SerializeField] Text ammoText;
    [SerializeField] AudioClip gunSound;

    private void OnEnable()
    {
        UpdateAmmoText();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetAmmoAmount(ammoType) > 0)
        {
            if(GetComponentInChildren<Animation>())
            {
                GetComponentInChildren<Animation>().Play();
            }
            GetComponent<AudioSource>().PlayOneShot(gunSound);
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.DecreaseAmmo(ammoType);
            UpdateAmmoText();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeAHit(shotPower);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject newHitEffect = Instantiate(hitEffect, hit.point, Quaternion.identity);
        Destroy(newHitEffect, 0.1f);
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    public void UpdateAmmoText()
    {
        ammoText.text = ammoSlot.GetAmmoAmount(ammoType).ToString();
    }
}
