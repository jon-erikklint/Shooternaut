using UnityEngine;
using System.Collections;
using System;

public class NullGrabbingComponent : MAIGrabbingComponent
{
    public override bool WillGrab()
    {
        return false;
    }

    public override bool WillRelease()
    {
        return false;
    }
}
