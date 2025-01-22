using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject planet;
    public float degreesPerSecond = 4.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        planet.transform.Rotate(0.0f, degreesPerSecond * Time.deltaTime, 0.0f);
    }
}
