using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LightSwitch : MonoBehaviour
{
    public Light light;
    public InputActionReference action;
    private Color color1 = new Color(1, 8 / 15.2f, 11 / 15.2f, 1); // First color (white)
    private Color color2 = new Color(1, 1, 1, 1); // Second color (red)
    private bool isColor1 = true; // Track current color state

    void Start()
    {
        light = GetComponent<Light>();
        action.action.Enable();
        action.action.performed += (ctx) => ToggleLightColor();
    }
    private void ToggleLightColor()
    {
        if (isColor1)
        {
            light.color = color2; // Change to the second color
        }
        else
        {
            light.color = color1; // Change to the first color
        }

        isColor1 = !isColor1; // Toggle the state
    }

    // Update is called once per frame
    void Update()
    {

    }
}
