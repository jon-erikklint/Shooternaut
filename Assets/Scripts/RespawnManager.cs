using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnManager : MonoBehaviour {

    private RespawnPoint spawnpoint;

    public Player player;
    public Survival survival;

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
        ResetHazards();
        ResetPlayer();
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

    private void ResetHazards()
    {
        

        OnRespawn[] activated = FindObjectsOfType<OnRespawn>();

        Debug.Log(activated.Length);

        foreach (OnRespawn activate in activated)
        {
            activate.onRespawn.Invoke();
        }
    }

    private void RemoveBullets()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Bullet");

        for(int i = projectiles.Length - 1 ; i >= 0; i--)
        {
            Destroy(projectiles[i]);
        }
    }
}
