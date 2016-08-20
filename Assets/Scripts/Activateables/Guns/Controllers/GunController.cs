using UnityEngine;
using System.Collections;

public abstract class GunController : MonoBehaviour {

    private Gun gun;
    public Actor owner;

    public virtual void Initialize()
    {
        gun = GetComponent<Gun>();
        owner = gun.owner;
    }

    public abstract bool CanShoot();

}
