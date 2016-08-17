using UnityEngine;
using System.Collections;

public class EnvironmentMine : OnDeathCreatorProjectile {

    private Vector3 startPosition;

    public override void init()
    {
        base.init();

        GetComponent<OnRespawn>().onRespawn.AddListener(Activate);
        startPosition = transform.position;
    }

    public override void DestroySelf()
    {
        OnDestruction();

        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }

    public void Activate()
    {
        transform.position = startPosition;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;

        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

}
