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
    private List<GameObject> allSpawns;

    public override void Init()
    {
        lastActive = Time.time - spawnInterval;
        currentAliveSpawns = new List<GameObject>();
        allSpawns = new List<GameObject>();
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
        allSpawns.Add(spawned);

        spawned.GetComponent<Destroyable>().deathEvent.AddListener(SpawnDies);
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

    public void SpawnDies(Destroyable destroyable)
    {
        Debug.Log("ASD");
        currentAliveSpawns.Remove(destroyable.gameObject);
    }

    public virtual int CurrentlyAliveSpawns()
    {
        return currentAliveSpawns.Count;
    }

    public virtual int SpawnedSpawns()
    {
        return allSpawns.Count;
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

        foreach(GameObject gameObject in allSpawns)
        {
            if(gameObject != null)
            {
                Destroy(gameObject);
            }
        }

        allSpawns = new List<GameObject>();
        currentAliveSpawns = new List<GameObject>();
    }

    public override ActivateableType Type()
    {
        return ActivateableType.Spawner;
    }
}
