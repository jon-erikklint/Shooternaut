using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Health : MonoBehaviour, HealthInterface{

    public float startHealth = 0;

    public float maxHealth { get { return _maxHealth; } }
    private float _maxHealth;

    public float currentHealth { get { return _currentHealth; } }
    private float _currentHealth;

    void Start()
    {
        _currentHealth = startHealth;
        _maxHealth = startHealth;
    }

    public void initialize(float startHealth)
    {
        _maxHealth = startHealth;
        _currentHealth = startHealth;
    }

    public void LoseHealth(float amount)
    {
        if(amount <= 0)
        {
            return;
        }

        _currentHealth = Math.Max(0, _currentHealth - amount);
    }

    public void SetHealth(float amount)
    {
        _currentHealth = Math.Max(Math.Min(_maxHealth, amount), 0);
    }

    public void GetHealth(float amount)
    {
        if(amount <= 0)
        {
            return;
        }

        _currentHealth = Math.Min(_maxHealth, _currentHealth + amount);
    }

    public bool Dead()
    {
        return _currentHealth <= 0;
    }

    public void Reset()
    {
        _currentHealth = _maxHealth;
    }

    public override string ToString()
    {
        return _currentHealth + "/" + _maxHealth;
    }

    
}
