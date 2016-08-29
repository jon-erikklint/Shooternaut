using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class RespawnPoint : MonoBehaviour{

    public int id;

    public Vector3 spawnpoint;

    public RespawnpointEvent respawnPointReached;

	void Awake () {

        if(spawnpoint.Equals(Vector3.zero))
        {
            spawnpoint = this.transform.position;
            spawnpoint.z = 0;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            respawnPointReached.Invoke(this);
        }
    }

    public int GetIndex()
    {
        return id;
    }
}
