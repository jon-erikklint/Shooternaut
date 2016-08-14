using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public int startHealth = 0;

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

        if(_currentHealth == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

}
