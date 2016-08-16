using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Exit : MonoBehaviour {

    public UnityEvent exitReached;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            exitReached.Invoke();
        }
    }
}
