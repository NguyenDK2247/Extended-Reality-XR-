using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    private bool grabbing = false;

    private Vector3 lastPosition;
    public Transform playerCamera;
    private Quaternion lastRotation;

    private void Start()
    {
        action.action.Enable();

        // Find the other hand
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }

        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void Update()
    {
        grabbing = action.action.IsPressed();

        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                //grabbedObject.transform.rotation = Quaternion.Euler(Vector3.zero);
                // Calculate delta position and rotation
                Vector3 deltaPosition = transform.position - lastPosition;
                Quaternion deltaRotation = Quaternion.Inverse(lastRotation) * transform.rotation;

                // Apply transformations
                grabbedObject.position += deltaRotation * (grabbedObject.position - transform.position) + deltaPosition;
                grabbedObject.rotation = deltaRotation * grabbedObject.rotation;

                // Update last position and rotation for next frame
                lastPosition = transform.position;
                lastRotation = transform.rotation;
            }
        }
        // If let go of button, release object
        else if (grabbedObject)
        {
            grabbedObject = null;
        }
        
        //Vector3 directionVector = transform.position - playerCamera.position;
        //// Position the lens camera in front of the player's camera
        //Vector3 lensPosition = transform.position + directionVector;
        //transform.LookAt(lensPosition, transform.up);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform t = other.transform;
        if (t && t.CompareTag("Grabbable"))
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if (t && t.CompareTag("Grabbable"))
            nearObjects.Remove(t);
    }
}