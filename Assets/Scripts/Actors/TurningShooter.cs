using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurningShooter : Shooter{

    public float turningSpeed;

    private Quaternion startRotation;

    public override void Init()
    {
        base.Init();

        Quaternion r = transform.rotation;

        startRotation = new Quaternion(r.x, r.y, r.z, r.w);
    }

    void Update()
    {
        mainMover.Move(new Vector2(1,0), 1*turningSpeed);
    }

    public override void Respawn(List<object> lastState)
    {
        base.Respawn(lastState);
        
        transform.rotation = startRotation;
    }
}
