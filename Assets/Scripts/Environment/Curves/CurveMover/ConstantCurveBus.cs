using UnityEngine;
using System.Collections;
using System;

public class ConstantCurveBus : AutomaticCurveBus {

    public float speed = 1.0f;
    public bool rotatesFreely;
    public float angularVelocity = 1.0f;

    public float time { get { return curve.length / speed; } }

    protected override void MovePosition(int i, float dt)
    {
//        GameObject obj = gameObjects[i];
        float currPos = gameObjectsPositions[i];
        gameObjectsPositions[i] = currPos + dt*speed;
    }

    protected override void RotateGameObject(int i, float dt)
    {
        GameObject obj = gameObjects[i];
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            obj.transform.Rotate(new Vector3(0, 0, angularVelocity * dt));
        }
        else
        {
            if (!rotatesFreely)
                rb.angularVelocity = angularVelocity * speedFactor;
        }
    }
}