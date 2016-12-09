using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public abstract class Destroyable: MonoBehaviour
{
    public DeathEvent deathEvent = new DeathEvent();

    public void Destroy()
    {
        DestroySelf();

        Debug.Log("SUD");
        deathEvent.Invoke(this);
    }

    protected virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
}

public class DeathEvent : UnityEvent<Destroyable>{}
