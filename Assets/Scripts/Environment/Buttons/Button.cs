using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Button : MonoBehaviour {

    public UnityEvent onPress;
    public List<string> tagList;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (tagList.Contains(col.gameObject.tag))
            onPress.Invoke();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (tagList.Contains(col.gameObject.tag))
            onPress.Invoke();
    }
}
