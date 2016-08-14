using UnityEngine;
using System.Collections;

public abstract class Activateable : MonoBehaviour {

    public Player owner;

    public abstract void Act();

}
