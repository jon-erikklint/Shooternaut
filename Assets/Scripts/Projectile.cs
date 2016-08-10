using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}