using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangingPOVs : MonoBehaviour
{
    public GameObject player;
    public InputActionReference action;
    private bool isInside = true; 

    void Start()
    {
        action.action.Enable();
        action.action.performed += (ctx) => switchPOV();
    }
    private void switchPOV()
    {
        if (isInside)
        {
            gameObject.transform.Translate(0, 0, -15); // Change to the oustide POV
        }
        else
        {
            gameObject.transform.Translate(0, 0, 15); // Change to the inside POV
        }

        isInside = !isInside; // Toggle the state
    }

    // Update is called once per frame
    void Update()
    {

    }
}
