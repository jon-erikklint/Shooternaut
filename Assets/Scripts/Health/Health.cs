using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Health : HealthInterface{

    public float startHealth = 0;

    public float maxHealth { get { return _maxHealth; } }
    private float _maxHealth = 0;

    public float currentHealth { get { return _currentHealth; } }
    private float _currentHealth = 0;

    void Start()
    {
        if(startHealth > 0)
        {
            initialize(startHealth);
        }
    }

    public void initialize(float startHealth)
    {
        _maxHealth = startHealth;
        _currentHealth = startHealth;
    }

    public override void LoseHealth(float amount)
    {
        if(amount <= 0)
        {
            return;
        }

        _currentHealth = Math.Max(0, _currentHealth - amount);
    }

    public override void SetHealth(float amount)
    {
        _currentHealth = Math.Max(Math.Min(_maxHealth, amount), 0);
    }

    public override void GetHealth(float amount)
    {
        if (amount <= 0)
        {
            return;
        }

        _currentHealth = Math.Min(_maxHealth, _currentHealth + amount);
    }

    public override bool Dead()
    {
        return _currentHealth <= 0;
    }

    public override bool FullHealth()
    {
        return currentHealth == maxHealth;
    }

    public override void Reset()
    {
        _currentHealth = _maxHealth;
    }

    public override string ToString()
    {
        return _currentHealth + "/" + _maxHealth;
    }

    public override float CurrentHealth()
    {
        return _currentHealth;
    }

    
}
