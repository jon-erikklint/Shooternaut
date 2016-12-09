using UnityEngine;
using System.Collections;

public class AmountLimitSpawner : Spawner{

    public float maxCurrentSpawns;
    public float maxLifetimeSpawns;

    public override bool CanActivate()
    {
        if (!base.CanActivate())
        {
            return false;
        }

        if(maxCurrentSpawns > 0)
        {
            if(CurrentlyAliveSpawns() >= maxCurrentSpawns)
            {
                return false;
            }
        }

        if(maxLifetimeSpawns > 0)
        {
            if(SpawnedSpawns() >= maxLifetimeSpawns)
            {
                return false;
            }
        }

        return true;
    }
}
