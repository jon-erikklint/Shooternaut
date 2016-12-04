using UnityEngine;
using System.Collections;
using System;

public class NullActivateableComponent : MAIActivateableComponent
{
    public override bool NextState()
    {
        return false;
    }
}
