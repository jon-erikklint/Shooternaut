using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class Health : MonoBehaviour {

    public int startHealth = 0;
    public UnityEvent onDeath;
    public UnityEvent onDamageTaken;

    public int currentHealth { get { return _currentHealth; } }
    private int _currentHealth;

    void Start()
    {
        _currentHealth = startHealth;
    }

    public void initialize(int startHealth)
    {
        this.startHealth = startHealth;
        _currentHealth = startHealth;
    }

    public void loseHealth(int amount)
    {
        _currentHealth = Math.Max(0, _currentHealth - amount);

        onDamageTaken.Invoke();

        if(_currentHealth == 0)
        {
            onDeath.Invoke();
        }
    }

}
