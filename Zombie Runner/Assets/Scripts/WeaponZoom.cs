using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] float zoomedIn = 40f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            mainCamera.GetComponent<Camera>().fieldOfView = zoomedIn;
        }
        else
        {
            mainCamera.GetComponent<Camera>().fieldOfView = zoomedOut;
        }
    }
}
