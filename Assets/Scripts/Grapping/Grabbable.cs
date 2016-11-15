using UnityEngine;
using System.Collections;

public interface Grabbable {

    bool CanGrab(Actor actor);

    bool Grab(Actor actor);
    bool Release(Actor actor);
}
