using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponSensitivity : MonoBehaviour
{
    [SerializeField] float sensZoomedIn = 1;
    [SerializeField] float sensZoomedOut = 2;
    RigidbodyFirstPersonController sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        sensitivity = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            sensitivity.mouseLook.XSensitivity = sensZoomedIn;
            sensitivity.mouseLook.YSensitivity = sensZoomedIn;
        }
        else
        {
            sensitivity.mouseLook.XSensitivity = sensZoomedOut;
            sensitivity.mouseLook.YSensitivity = sensZoomedOut;
        }
    }
}
