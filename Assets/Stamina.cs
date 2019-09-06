using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField] float timer = 5f;

    [SerializeField] public bool canRun = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            DecreaseTimer();
        }

        else if (timer != 5f)
        {
            IncreaseTimer();
        }
    }

    private void IncreaseTimer()
    {
        if(timer<5f) timer += 1f * Time.deltaTime;

        if(timer>=5f && !canRun)
        {
            canRun = true;
        }
    }

    private void DecreaseTimer()
    {

        if(timer > 0f) timer -= 1f * Time.deltaTime;

        if (timer <=0f)
        {
            canRun = false;
        }
    }
}
