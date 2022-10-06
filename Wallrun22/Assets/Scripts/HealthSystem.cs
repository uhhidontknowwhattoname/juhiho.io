using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class HealthSystem : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float currentHealth;
    public float damageAmount = 15;
    public TextMeshProUGUI text;

    

    private void Start()
    {
        
        currentHealth = MaxHealth;
    }

    private void Update()
    {
        

        text.SetText("Health : " + currentHealth);
    }

    void Oof()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void damage1(int boobs)
    {
        
        Debug.Log(currentHealth -= boobs);

        if (currentHealth <= 0)
        {
            Oof();
        }
    }

   
}
