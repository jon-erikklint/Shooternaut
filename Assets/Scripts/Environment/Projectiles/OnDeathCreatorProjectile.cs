using UnityEngine;
using System.Collections;
using System;

public class OnDeathCreatorProjectile : NormalProjectile {

    public GameObject prefab;

    public override void OnDestruction()
    {
        GameObject instantiated = Instantiate(prefab);
        instantiated.transform.position = transform.position;
    }

}
