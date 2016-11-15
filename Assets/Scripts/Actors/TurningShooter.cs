using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurningShooter : Shooter{

    public float secondsPerRevolution;

    private Quaternion startRotation;

    public override void init()
    {
        base.init();

        Quaternion r = transform.rotation;

        startRotation = new Quaternion(r.x, r.y, r.z, r.w);
    }

    void Update()
    {
        float rotation = 360 * (Time.deltaTime / secondsPerRevolution);

        transform.Rotate(new Vector3(0, 0, rotation));
    }

    public override void Respawn(List<object> lastState)
    {
        base.Respawn(lastState);
        
        transform.rotation = startRotation;
    }
}
