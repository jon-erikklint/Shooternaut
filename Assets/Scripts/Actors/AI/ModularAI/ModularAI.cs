using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ModularAI : AI {

    public MAIMovementComponent mainMovementComponent;
    public MAIMovementComponent secondaryMovementComponent;
    public MAIActivateableComponent mainActivateableComponent;
    public MAIActivateableComponent secondaryActivateableComponent;
    public MAIGrabbingComponent grabbingComponent;

    private List<MAIComponent> updateComponents;

    public override void Init()
    {
        base.Init();
        
        updateComponents = new List<MAIComponent>();

        InitComponent(mainMovementComponent, mainMover);
        InitComponent(secondaryMovementComponent, secondaryMover);
        InitComponent(mainActivateableComponent, mainActivateable);
        InitComponent(secondaryActivateableComponent, secondaryActivateable);
        InitComponent(grabbingComponent, null);
    }

    private void InitComponent(MAIComponent component, object extraArgument)
    {
        if(component == null || extraArgument == null)
        {
            return;
        }

        if (component is MAIActivateableComponent)
        {
            MAIActivateableComponent ac = (MAIActivateableComponent) component;

            ac.Init(this, (Activateable) extraArgument);
        }else if(component is MAIMovementComponent)
        {
            MAIMovementComponent mc = (MAIMovementComponent) component;

            mc.Init(this, (Mover)extraArgument);
        }
        else
        {
            component.Init(this);
        }

        updateComponents.Add(component);
    }

    void Update()
    {
        foreach(MAIComponent component in updateComponents)
        {
            component.Act();
        }
    }

    protected override void Deactivate()
    {
        foreach(MAIComponent component in updateComponents)
        {
            component.TurnOff();
        }
    }

    protected override void Activate()
    {
        foreach (MAIComponent component in updateComponents)
        {
            component.TurnOn();
        }
    }
}
