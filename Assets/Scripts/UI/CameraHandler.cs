using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {

    public float howFarAway = -10f;
    public float smoothness = 7.0f;
    public float mouseSensitivity = 0.2f;
    public float maxLookDistance = 1.0f;
    public bool inverse = false;

    private Transform playerTransform;
    private Transform cameraTransform;

    void Start()
    {
        Debug.Log("Start!");
        playerTransform = FindObjectOfType<Player>().transform;
        cameraTransform = transform.Find("Main Camera");
    }
    
	void FixedUpdate () {
        Vector3 newPos = playerTransform.position;
        newPos.z = howFarAway;
        
        transform.position = Vector3.Lerp(transform.position, newPos, smoothness * Time.deltaTime);
        if (inverse)
        {
            cameraTransform.localPosition = 2 * (newPos - transform.position);
        }
        else
        {
            cameraTransform.localPosition = Vector3.zero;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 lookingVector = mousePosition - playerTransform.position;

        cameraTransform.localPosition += (lookingVector).normalized * Mathf.Min(lookingVector.magnitude*mouseSensitivity, maxLookDistance);
    }
}
