using UnityEngine;
using System.Collections;

public class DamagingSpikes : MonoBehaviour {

    public float damage;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<Player>().LoseHealth(damage);
        }
    }
}
