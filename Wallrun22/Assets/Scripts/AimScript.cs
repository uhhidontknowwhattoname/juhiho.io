﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{

    public GameObject Gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(1))
        {
            Gun.GetComponent<Animator>().Play("gunADS");
        }

        if (Input.GetMouseButtonUp(1))
        {
            Gun.GetComponent<Animator>().Play("New State");
        }
    }
}
