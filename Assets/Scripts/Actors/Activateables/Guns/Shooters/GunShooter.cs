using UnityEngine;
using System.Collections;

public abstract class GunShooter : MonoBehaviour {

    private Gun gun;
    public Actor owner;

    public virtual void Initialize()
    {
        gun = GetComponent<Gun>();
        owner = gun.owner;
    }

    public abstract bool AbleToShoot();

    public abstract void Shoot();
    public abstract void CantShoot();
    public abstract void Deactivate();

    public abstract Vector3 KnockBackAmount();

    public virtual void Reset() { }

    protected Vector3 FacedDirection()
    {
        return owner.Angle();
    }
}
