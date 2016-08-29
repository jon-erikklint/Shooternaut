using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class RespawnManager : MonoBehaviour {

    public UnityEvent respawn;
    public RespawnpointEvent respawnPointReached;

    public Player player;
    public Survival survival;

    void Start()
    {
        AddRespawnPointListeners();

        player = FindObjectOfType<Player>();
        player.playerDies.AddListener(TryRespawn);
    }

    private void AddRespawnPointListeners()
    {
        RespawnPoint[] respawns = FindObjectsOfType<RespawnPoint>();

        foreach(RespawnPoint respawn in respawns)
        {
            respawn.respawnPointReached.AddListener(SpawnpointReached);
        }
    }

    public void SpawnpointReached(RespawnPoint newSpawnpoint)
    {
        respawnPointReached.Invoke(newSpawnpoint);
    }

    public void TryRespawn()
    {
        if (CanRespawn())
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        respawn.Invoke();
    }

    public bool CanRespawn()
    {
        if (survival == null)
        {
            return true;
        }

        return survival.lives > 0;
    }
}
