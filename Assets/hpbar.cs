using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hpbar : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 20;

    private int currentHealth;

    public event Action<float> OnHealthPercentage = delegate { };
    

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void modifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthpct = (float)currentHealth / (float)maxHealth;

        OnHealthPercentage(currentHealthpct);

    }

    
    void Update()
    {
        
    }
}
