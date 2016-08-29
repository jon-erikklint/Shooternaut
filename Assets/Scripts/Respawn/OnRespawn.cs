using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnRespawn : MonoBehaviour {

    private Dictionary<Respawnable, List<object>> respawnStates;

    void Awake()
    {
        RespawnManager rm = FindObjectOfType<RespawnManager>();

        rm.respawn.AddListener(Respawn);
        rm.respawnPointReached.AddListener(RespawnPointReached);

        respawnStates = new Dictionary<Respawnable, List<object>>();
    }

    public void Respawn()
    {
        if(respawnStates.Count <= 0)
        {
            Destroy(this.gameObject);
            return;
        }

        List<Respawnable> respawnables = Respawnables();

        foreach(Respawnable respawnable in respawnables)
        {
            if (respawnStates.ContainsKey(respawnable))
            {
                respawnable.Respawn(respawnStates[respawnable]);
            }
            else
            {
                Destroy(respawnable as Object);
            }
        }
    }

    public void RespawnPointReached(RespawnPoint respawnPoint)
    {
        respawnStates = new Dictionary<Respawnable, List<object>>();

        List<Respawnable> respawnables = Respawnables();

        foreach(Respawnable respawnable in respawnables)
        {
            respawnStates.Add(respawnable, respawnable.RespawnPointReached(respawnPoint));
        }
    }

    private List<Respawnable> Respawnables()
    {
        return new List<Respawnable>(GetComponents<Respawnable>());
    }
}
