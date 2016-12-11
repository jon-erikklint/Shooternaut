using UnityEngine;
using System.Collections;

public abstract class HealthInterface: MonoBehaviour{

    public abstract void LoseHealth(float amount);

    public abstract void GetHealth(float amount);

    public abstract void SetHealth(float amount);

    public abstract float CurrentHealth();

    public abstract bool Dead();

    public abstract bool FullHealth();

    public abstract float HealthPercentage();

    public abstract void Reset();

}
