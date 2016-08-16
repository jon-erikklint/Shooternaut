using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

[Serializable]
public class SpawnpointEvent : UnityEvent<RespawnPoint> { }

public class RespawnPoint : MonoBehaviour {

    public Vector3 spawnpoint;

    public SpawnpointEvent respawnPointReached;

	void Start () {
        respawnPointReached.AddListener(FindObjectOfType<RespawnManager>().SetSpawnpoint);

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

}
