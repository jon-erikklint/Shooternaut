﻿using UnityEngine;
using System.Collections;
using System;

public class NoController : GunController {

	public override bool TryToShoot()
    {
        return true;
    }

    public override bool CanShoot()
    {
        return true;
    }

    public override bool FullClip()
    {
        return true;
    }

    public override void Reset(){}

}
