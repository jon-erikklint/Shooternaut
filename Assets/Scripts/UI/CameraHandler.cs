using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {

    public float howFarAway = -10f;
    public float smoothness = 7.0f;

    private Transform playerTransform;

    void Start()
    {
        Debug.Log("Start!");
        playerTransform = FindObjectOfType<Player>().transform;
    }
    
	void FixedUpdate () {
        Vector3 newPos = playerTransform.position;
        newPos.z = howFarAway;

        transform.position += Vector3.Lerp(Vector3.zero, (newPos - transform.position), smoothness * Time.deltaTime);

    }
}
