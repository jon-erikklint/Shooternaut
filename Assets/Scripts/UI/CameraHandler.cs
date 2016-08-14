using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {

    public float howFarAway;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }
    
	void Update () {
        Vector3 newPosition = playerTransform.position;
        newPosition.z = howFarAway;

        transform.position = newPosition;
	}
}
