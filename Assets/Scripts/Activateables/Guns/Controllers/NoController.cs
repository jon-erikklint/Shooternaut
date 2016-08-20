using UnityEngine;
using System.Collections;

public class NoController : GunController {

	public override bool CanShoot()
    {
        return true;
    }
}
