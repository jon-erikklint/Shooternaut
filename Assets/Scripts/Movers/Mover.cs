using UnityEngine;
using System.Collections;

public abstract class Mover: MonoBehaviour {

    public abstract void Move(Vector2 direction, float magnitude);

    public abstract void Init(Actor actor);
}
