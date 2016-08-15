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
            Die();
        }
    }

    public void setHealth(float amount)
    {
        _currentHealth = Math.Max(Math.Min(startHealth, amount), 0);
        
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Projectile proj = collision.gameObject.GetComponent<Projectile>();

            loseHealth(proj.Damage());
        }
    }

    public void Die()
    {
        onDeath.Invoke();
    }

}
