using UnityEngine;
using System.Collections;

public abstract class Activateable : Destroyable {

    public Actor owner;

    public abstract bool Act();

}
