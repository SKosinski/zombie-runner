using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .001f;
    [SerializeField] float angleDecay = .001f;
    [SerializeField] float minimumAngle = 5f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightIntensity()
    {
        if (myLight.range>minimumAngle)
        {
            myLight.range -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightAngle()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    public void RestoreLight()
    {
        myLight.range = 20f;
        myLight.intensity = 7f;
    }
}
