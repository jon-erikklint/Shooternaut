using UnityEngine;
using System.Collections;

public class MultipleHitProjectile : NormalProjectile {

    public int hitTimes;

    public override bool GetsDestroyed(string colliderTag)
    {
        bool isDamaged = base.GetsDestroyed(colliderTag);

        if (!isDamaged)
        {
            return false;
        }

        hitTimes--;

        return hitTimes <= 0;
    }
	
}
