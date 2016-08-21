using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnManager : MonoBehaviour {

    private RespawnPoint spawnpoint;

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
            respawn.respawnPointReached.AddListener(SetSpawnpoint);
        }
    }

    public void SetSpawnpoint(RespawnPoint newSpawnpoint)
    {
        spawnpoint = newSpawnpoint;
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
        if (survival != null)
        {
            survival.lives--;
        }
        
        RemoveBullets();
        RemoveExplosions();
        Invoke("Reset", 0.05f);
    }

    private void Reset()
    {
        ResetScripts();
        ResetPlayer();
        ResetActivateables();
    }

    private void ResetActivateables()
    {
        Activateable[] activateables = FindObjectsOfType<Activateable>();

        foreach(Activateable act in activateables)
        {
            act.Reset();
        }
    }

    private void ResetPlayer()
    {
        player.health.Reset();

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        player.transform.position = spawnpoint.spawnpoint;
        player.transform.localRotation = Quaternion.identity;
    }

    public bool CanRespawn()
    {
        if (survival == null)
        {
            return true;
        }

        return survival.lives > 0;
    }

    private void ResetScripts()
    {
        OnRespawn[] activated = FindObjectsOfType<OnRespawn>();

        foreach (OnRespawn activate in activated)
        {
            activate.onRespawn.Invoke();
        }
    }

    private void RemoveExplosions()
    {
        GameObject[] explosions = GameObject.FindGameObjectsWithTag("Explosion");

        for (int i = explosions.Length - 1; i >= 0; i--)
        {
            explosions[i].GetComponent<Destroyable>().DestroySelf();
        }
    }

    private void RemoveBullets()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Bullet");

        DestroyAll(projectiles);
    }

    private void DestroyAll(GameObject[] destroy)
    {
        for (int i = destroy.Length - 1; i >= 0; i--)
        {
            Destroy(destroy[i]);
        }
    }
}
