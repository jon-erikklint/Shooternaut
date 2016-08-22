using UnityEngine;
using System.Collections;

public interface HealthInterface {

    void LoseHealth(float amount);

    void GetHealth(float amount);

    void SetHealth(float amount);

    float CurrentHealth();

    bool Dead();

    void Reset();

}
