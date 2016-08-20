using UnityEngine;
using System.Collections;
using System;

public abstract class GunController : MonoBehaviour{

    private Gun gun;
    public Actor owner;

    public virtual void Initialize()
    {
        gun = GetComponent<Gun>();
        owner = gun.owner;
    }

    public abstract bool CanShoot();

    public GameObject UIElement()
    {
        GameObject uiElement = transform.GetChild(0).gameObject;
        initialize(uiElement);

        return uiElement;
    }

    public abstract void initialize(GameObject uiElement);
}
