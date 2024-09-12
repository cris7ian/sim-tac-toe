using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private  Quaternion initialRotation;
    private float initialFOV;
    private Vector3 offset;    // Start is called before the first frame update\
    public float trackingSpeed = 3.0f;
    public float zoomingSpeed = 10f;
    void Start()
    {
        initialRotation = transform.rotation;
        initialFOV = Camera.main.fieldOfView;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        if (isPlayerActive())
        {
            lookAtPlayer();
        } else {
            resetCamera();
        }
    }

    private bool isPlayerActive()
    {
        return PlayerController.activePlayer != null;
    }

    private void resetCamera()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, trackingSpeed * Time.deltaTime);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60f, zoomingSpeed * Time.deltaTime);
    }
    
    private void lookAtPlayer()
    {
        Vector3 direction = PlayerController.activePlayer.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, trackingSpeed * Time.deltaTime);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 40f, zoomingSpeed * Time.deltaTime);
    }
}
