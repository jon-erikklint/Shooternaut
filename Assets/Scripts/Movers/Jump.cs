using UnityEngine;
using System.Collections;
using System;

public class Jump : Mover
{
    private float prevJump;
    private float cooldown = 0.1f;

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

        Transform feet = owner.transform.FindChild("Feet");

        if (feet == null)
            return;

        RaycastHit2D hit = Physics2D.Raycast(feet.position, -direction, 0.5f);

        if (hit.collider == null || hit.collider.gameObject.tag != "Wall")
            return;

        owner.GetComponent<Rigidbody2D>().AddForce(direction.normalized * magnitude, ForceMode2D.Impulse);
        hit.rigidbody.AddForce(-direction.normalized * magnitude, ForceMode2D.Impulse);
    }
}
