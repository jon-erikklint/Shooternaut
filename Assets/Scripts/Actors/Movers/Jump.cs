using UnityEngine;
using System.Collections;
using System;

public class Jump : Mover
{
    public float jumpFeetLength = 0.25f;
    public float cooldown = 0.1f;

    private float prevJump;

    protected override void Init()
    {
        prevJump = Time.time - cooldown;
    }

    public override void Move(Vector2 direction, float magnitude)
    {
        if(owner == null)
        {
            Debug.Log("Olen yksin... :(");
            return;
        }

        if (Time.time - prevJump < cooldown)
            return;

        Vector2 feetPosition = owner.FeetPosition();

        RaycastHit2D hit = Physics2D.Raycast(feetPosition, -direction, jumpFeetLength);

        if (hit.collider == null || hit.collider.gameObject.tag != "Wall")
            return;

        owner.GetComponent<Rigidbody2D>().AddForce(direction.normalized * magnitude, ForceMode2D.Impulse);

        if(hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-direction.normalized * magnitude, ForceMode2D.Impulse);
        }
    }
}
