using UnityEngine;
using System.Collections;
using System;

public abstract class Condition: Respawnable{

    public abstract void Begin();
    public abstract void End();

    public abstract string Name();
    public abstract string Description();

    public abstract bool Lost();

    public GameObject UIElement()
    {
        GameObject uiElement = transform.GetChild(0).gameObject;
        initialize(uiElement);

        return uiElement;
    }

    public abstract void initialize(GameObject uiElement);
    
}
