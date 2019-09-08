using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class MovementHandler : MonoBehaviour
{

    RigidbodyFirstPersonController rigidbodyFPC;

    [SerializeField] public AudioClip walkingSFX;
    [SerializeField] public AudioClip runningSFX;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyFPC = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    private void movementSound()
    {
        if(!GetComponent<AudioSource>().isPlaying)
        {
            if (rigidbodyFPC.movementSettings.m_Running && rigidbodyFPC.movementSettings.m_Walking)
            {
                GetComponent<AudioSource>().PlayOneShot(runningSFX);
            }
            else if (!rigidbodyFPC.movementSettings.m_Running && rigidbodyFPC.movementSettings.m_Walking)
            {
                GetComponent<AudioSource>().PlayOneShot(walkingSFX);
            }
        }
        if(GetComponent<AudioSource>().isPlaying)
        {
            if((!rigidbodyFPC.movementSettings.m_Running && !rigidbodyFPC.movementSettings.m_Walking) || rigidbodyFPC.Jumping)
            {
                GetComponent<AudioSource>().Stop();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        movementSound();
        HeadBob();
    }

    private void HeadBob()
    {
        if (rigidbodyFPC.Jumping == true)
        {
            GetComponent<Animator>().SetBool("isJumping", true);
        }

        else
        {
            GetComponent<Animator>().SetBool("isJumping", false);
        }

        if (rigidbodyFPC.movementSettings.m_Running && rigidbodyFPC.movementSettings.m_Walking)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
            GetComponent<Animator>().SetBool("isWalking", false);
        }

        else if (!rigidbodyFPC.movementSettings.m_Running && rigidbodyFPC.movementSettings.m_Walking)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            GetComponent<Animator>().SetBool("isRunning", false);
        }

        else if (!rigidbodyFPC.movementSettings.m_Running && !rigidbodyFPC.movementSettings.m_Walking)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            GetComponent<Animator>().SetBool("isRunning", false);
        }
    }
}
