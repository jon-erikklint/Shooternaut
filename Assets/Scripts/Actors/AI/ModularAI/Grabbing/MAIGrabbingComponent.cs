using UnityEngine;
using System.Collections;

public abstract class MAIGrabbingComponent : MAIComponent {

    public abstract bool WillGrab();
    public abstract bool WillRelease();

}
