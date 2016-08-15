using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {

    public float howFarAway = -10f;         // How high the camera is
    public float smoothness = 7.0f;         // How smooth the camera moves - lower value, smoother camera
    public float mouseSensitivity = 0.1f;   // How strongly camera reacts to mouse position. Must be within range ]-1,1[

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

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 lookingVector = mousePosition - playerTransform.position;

        cameraTransform.localPosition = lookingVector * mouseSensitivity;
    }
}
