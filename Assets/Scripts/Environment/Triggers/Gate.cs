using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Gate : Respawnable
{
    public List<Trigger> openButtons;
    public List<Trigger> closeButtons;

    public bool saveStateOverRespawn;
    public bool openAtBeginning;

    public bool open { get { return _open; } }
    private bool _open;

    public override void Init()
    {
        if (openAtBeginning)
        {
            Open();
        }

        foreach(Trigger trigger in openButtons)
        {
            trigger.onPress.AddListener(Open);
        }

        foreach(Trigger trigger in closeButtons)
        {
            trigger.onPress.AddListener(Close);
        }
    }

    public void Open()
    {
        _open = true;

        gameObject.SetActive(false);
    }

    public void Close()
    {
        _open = false;

        gameObject.SetActive(true);
    }

    public override bool Respawn(List<object> lastState)
    {
        if (!saveStateOverRespawn)
        {
            if (openAtBeginning)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        return true;
    }

    public override List<object> RespawnPointReached(RespawnPoint respawn)
    {
        return new List<object>();
    }
}
