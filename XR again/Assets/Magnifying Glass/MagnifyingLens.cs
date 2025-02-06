using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingLens : MonoBehaviour
{
    public Transform playerCamera; // Reference to the player's main camera
    public Transform magnifyingGlass;

    private void Start()
    {
    }

    private void Update()
    {
        PositionLensCamera();
    }

    private void PositionLensCamera()
    {   
        transform.rotation = magnifyingGlass.transform.rotation;

        Vector3 directionVector = transform.position - playerCamera.position;
        // Position the lens camera in front of the player's camera
        Vector3 lensPosition = transform.position + directionVector;
        transform.LookAt(lensPosition, magnifyingGlass.transform.up);
        
        Debug.Log("rot: " + transform.rotation);

        
    }
}
