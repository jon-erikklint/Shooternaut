using UnityEngine;
using System.Collections;

public class ExplosiveProjectile : MonoBehaviour {

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject boom = Instantiate(explosion);
        boom.transform.position = transform.position;
        Destroy(gameObject);
    }

}
