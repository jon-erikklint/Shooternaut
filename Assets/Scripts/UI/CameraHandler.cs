﻿using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {

    public float howFarAway = 5f;           // How high the camera is
    public float howFarStart = 8f;          // How high the camera is at spawn
    public float zoomOutFactor = 0.15f;     // How much camera zooms out in movement
    public float zoomOutSpeed = 7f;         // How quickly zooming happens
    public float smoothness = 7.0f;         // How smooth the camera moves - lower value, smoother camera
    public float mouseSensitivity = 0.1f;   // How strongly camera reacts to mouse position. Must be within range ]-1,1[
    public float mouseSmoothness = 7f;      // How quickly camera reacts to mouse position. Must be >0.

    private Transform playerTransform;
    private Transform cameraTransform;
    private Camera mainCamera;
    private float z;
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        cameraTransform = transform.Find("Main Camera");
        mainCamera = cameraTransform.GetComponent<Camera>();
        mainCamera.orthographicSize = howFarAway;
        z = transform.position.z;

        Vector3 playerPos = playerTransform.position;

        this.transform.position = new Vector3(playerPos.x, playerPos.y, z);
        mainCamera.orthographicSize = howFarStart;
    }
    
	void FixedUpdate () {
        // Smooth movement:
        Vector3 newPos = playerTransform.position;
        newPos.z = z;
        
        transform.position = Vector3.Lerp(transform.position, newPos, smoothness * Time.deltaTime);

        // Camera zooming out due to speed:
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, howFarAway*(1 + (newPos - transform.position).magnitude * zoomOutFactor), zoomOutSpeed*Time.deltaTime);
        
        // Smooth mouse following:
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = howFarAway;

        Vector3 lookingVector = mousePosition - newPos;

        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, lookingVector * mouseSensitivity, mouseSmoothness*Time.deltaTime);
    }
}
