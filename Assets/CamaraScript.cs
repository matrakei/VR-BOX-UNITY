using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CamaraScript : MonoBehaviour
{
    private Vector3 initialPosition;
    private float targetAspectRatio = 1.7777f;
    public float targetFOV = 60f;

    void Start()
    {
        // Guarda la posición inicial de la cámara
        initialPosition = transform.position;
        Camera.main.aspect = targetAspectRatio;
        Camera.main.fieldOfView = targetFOV;
    }

    void LateUpdate()
    {
        // Mantén la cámara en la misma posición
        transform.position = initialPosition;
    }
}
