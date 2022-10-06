using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtMyBalls : MonoBehaviour
{
    public HealthSystem health;
    


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
            int boobs = 15;
            health.damage1(boobs);
        }
    }
}
