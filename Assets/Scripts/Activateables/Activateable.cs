using UnityEngine;
using System.Collections;

public abstract class Activateable : Destroyable {

    public Player owner;

    public abstract bool Act();

}
