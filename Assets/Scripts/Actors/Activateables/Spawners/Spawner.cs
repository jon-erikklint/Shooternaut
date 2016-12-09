using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Spawner : Activateable
{
    public GameObject prefab;
    public GameObject spawnsParent;
    public Vector2 spawnPosition;
    public bool relativeSpawn;

    public float spawnInterval;

    private float lastActive;

    private List<GameObject> currentAliveSpawns;
    private int spawnedAmount;

    public override void Init()
    {
        lastActive = Time.time - spawnInterval;
        currentAliveSpawns = new List<GameObject>();
        spawnedAmount = 0;
    }

    void Update()
    {
        if (active && CanActivate())
        {
            Spawn();
            lastActive = Time.time;
        }
    }

    public void Spawn()
    {
        GameObject spawned = InstantiateSpawn();

        currentAliveSpawns.Add(spawned);

        spawnedAmount++;
    }

    private GameObject InstantiateSpawn()
    {
        GameObject spawned = Instantiate(prefab);

        Vector3 position = new Vector3(spawnPosition.x, spawnPosition.y, spawned.transform.position.z);

        if (relativeSpawn)
        {
            Vector2 op = owner.transform.position;
            position += new Vector3(op.x, op.y, 0);
        }

        spawned.transform.position = position;

        if (spawnsParent != null)
        {
            spawned.transform.parent = spawnsParent.transform;
        }

        return spawned;
    }

    public virtual int CurrentlyAliveSpawns()
    {
        return currentAliveSpawns.Count;
    }

    public virtual int SpawnedSpawns()
    {
        return spawnedAmount;
    }

    public override bool CanActivate()
    {
        return Time.time >= lastActive + spawnInterval;
    }

    public override bool FullActivate()
    {
        return CanActivate();
    }

    public override void Reset()
    {
        base.Reset();

        lastActive = 0;
        spawnedAmount = 0;

        foreach(GameObject gameObject in currentAliveSpawns)
        {
            if(gameObject != null)
            {
                Destroy(gameObject);
            }
        }
        currentAliveSpawns = new List<GameObject>();
    }

    public override ActivateableType Type()
    {
        return ActivateableType.Spawner;
    }
}
