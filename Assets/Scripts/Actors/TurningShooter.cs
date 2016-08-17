using UnityEngine;
using System.Collections;

public class TurningShooter : Shooter{

    public float secondsPerRevolution;

    public override void Act()
    {
        float rotation = 360 * (Time.deltaTime / secondsPerRevolution);

        transform.Rotate(new Vector3(0, 0, rotation));
    }
}
