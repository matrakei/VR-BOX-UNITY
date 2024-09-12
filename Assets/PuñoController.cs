using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuñoController : MonoBehaviour
{
    public float velocidadMinimaGolpe = 1.0f;
    public Vector3 posicionAnterior;
    public float velocidadActual;
    private static bool golpeValido = false;

    void Start()
    {
        // Inicializa la posición anterior con la posición inicial del objeto
        posicionAnterior = transform.position;
    }

    void Update()
    {
        // Calcula la velocidad como el cambio de posición por segundo
        velocidadActual = (transform.position - posicionAnterior).magnitude / Time.deltaTime;

        // Actualiza la posición anterior para el siguiente frame
        posicionAnterior = transform.position;

        // Verifica si la velocidad actual supera el umbral
        if (velocidadActual > velocidadMinimaGolpe)
        {
            golpeValido = true;
        }
        else
        {
            golpeValido = false;
        }
    }

    public static bool EsGolpeValido()
    {
        return golpeValido;
    }
}