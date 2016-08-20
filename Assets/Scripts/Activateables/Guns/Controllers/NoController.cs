using UnityEngine;
using System.Collections;
using System;

public class NoController : GunController {

	public override bool CanShoot()
    {
        return true;
    }

    public override void initialize(GameObject uiElement)
    {
        
    }
}
