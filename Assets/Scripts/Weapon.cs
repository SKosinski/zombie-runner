using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    [Header("Basics")]
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Text ammoText;
    [SerializeField] public bool canAttack = true;
    [Space(10)]

    [Header("Gun")]
    [SerializeField] float shotRange = 100f;
    [SerializeField] int shotPower = 1;
    [SerializeField] GameObject shotEffect;
    [SerializeField] AudioClip shotSound;
    [SerializeField] float timeBetweenShots = 0;
    [Space(10)]

    [Header("Knife")]
    [SerializeField] bool canStab = false;
    [SerializeField] float stabRange = 2f;
    [SerializeField] int stabPower = 5;
    [SerializeField] GameObject stabEffect;
    [SerializeField] AudioClip stabSound;
    [SerializeField] float timeBetweenStabs = 2;



    private void OnEnable()
    {
        UpdateAmmoText();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canAttack)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetButtonDown("Fire3") && canAttack)
        {
            StartCoroutine(Stab());
        }
    }

    IEnumerator Shoot()
    {
        canAttack = false;
        if (ammoSlot.GetAmmoAmount(ammoType) > 0)
        {
            if(GetComponentInChildren<Animation>())
            {
                GetComponentInChildren<Animation>().Play("Shoot");
            }

            GetComponent<AudioSource>().PlayOneShot(shotSound);
            PlayMuzzleFlash();
            ProcessRaycast(shotRange, shotPower, shotEffect);
            ammoSlot.DecreaseAmmo(ammoType);
            UpdateAmmoText();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canAttack = true;
    }

    IEnumerator Stab()
    {
        canAttack = false;


        if (GetComponentInChildren<Animation>())
        {
            GetComponentInChildren<Animation>().Play("Stab");
        }

        //TODO GetComponent<AudioSource>().PlayOneShot(stabSound);

        ProcessRaycast(stabRange, stabPower, stabEffect);
        yield return new WaitForSeconds(timeBetweenStabs);
        canAttack = true;
    }

    private void ProcessRaycast(float range, int power, GameObject effect)
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit, effect);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeAHit(power);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit, GameObject effect)
    {
        GameObject newHitEffect = Instantiate(effect, hit.point, Quaternion.identity);
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
