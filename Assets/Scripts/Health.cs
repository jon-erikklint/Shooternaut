using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Health : MonoBehaviour {

    public float startHealth = 0;
    public UnityEvent onDeath;
    public UnityEvent onDamageTaken;

    public float currentHealth { get { return _currentHealth; } }
    private float _currentHealth;

    void Start()
    {
        _currentHealth = startHealth;
    }

    public void initialize(float startHealth)
    {
        this.startHealth = startHealth;
        _currentHealth = startHealth;
    }

    public void loseHealth(float amount)
    {
        if(amount <= 0)
        {
            return;
        }

        _currentHealth = Math.Max(0, _currentHealth - amount);

        onDamageTaken.Invoke();

        if(_currentHealth <= 0)
        {
            onDeath.Invoke();
        }
    }

}
