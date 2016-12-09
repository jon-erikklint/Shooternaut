using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class RespawnManager : MonoBehaviour {
    
    private Dictionary<Respawnable, List<object>> respawnStates;
    private List<Respawnable> newRespawnables;
    
    public Survival survival;

    void Awake()
    {
        AddRespawnPointListeners();

        FindObjectOfType<Player>().deathEvent.AddListener(TryRespawn);
        survival = FindObjectOfType<Survival>();

        respawnStates = new Dictionary<Respawnable, List<object>>();
        newRespawnables = new List<Respawnable>();
    }

    private void AddRespawnPointListeners()
    {
        RespawnPoint[] respawns = FindObjectsOfType<RespawnPoint>();

        foreach(RespawnPoint respawn in respawns)
        {
            respawn.respawnPointReached.AddListener(RespawnPointReached);
        }
    }

    public void TryRespawn(Destroyable player)
    {
        if (CanRespawn())
        {
            Respawn();
        }
    }

    public bool CanRespawn()
    {
        if (survival == null)
        {
            return true;
        }

        return survival.lives > 0;
    }

    public void Respawn()
    {
        foreach (Respawnable respawnable in newRespawnables)
        {
            if(respawnable != null)
            {
                respawnable.Destroy();
            }
        }

        newRespawnables = new List<Respawnable>();

        List<Respawnable> destroy = new List<Respawnable>();

        foreach (Respawnable respawnable in respawnStates.Keys)
        {
            bool survived;
            if (respawnable == null)
            {
                survived = false;
            }
            else
            {
                List<object> newList = new List<object>(respawnStates[respawnable]);
                survived = respawnable.Respawn(newList);
            }
            

            if (!survived)
            {
                destroy.Add(respawnable);
            }
        }

        foreach(Respawnable d in destroy)
        {
            respawnStates.Remove(d);
        }
    }

    public void RespawnPointReached(RespawnPoint respawnPoint)
    {
        List<Respawnable> respawnables = new List<Respawnable>(respawnStates.Keys);
        respawnables.AddRange(newRespawnables);

        respawnStates = new Dictionary<Respawnable, List<object>>();
        newRespawnables = new List<Respawnable>();

        foreach (Respawnable respawnable in respawnables)
        {
            respawnStates.Add(respawnable, respawnable.RespawnPointReached(respawnPoint));
        }
    }

    public void AddMe(Respawnable respawnable)
    {
        newRespawnables.Add(respawnable);
    }
}
