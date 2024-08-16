using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    public GameObject PERSONAJE;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que colisionó es una mano
        Debug.Log("DETECCION");
            DetectarLado(other);
        
    }

    private void DetectarLado(Collider manoCollider)
    {
        Debug.Log("DETECCION 2");

        // Obtén la posición del colisionador de la mano
        Vector3 manoPosition = manoCollider.transform.position;

        Debug.Log("DETECCION 3");
        // Calcula la dirección desde el personaje hacia la mano
        Vector3 direction = manoPosition - PERSONAJE.transform.position;
        Debug.Log("DETECCION 4");
        // Proyecta la dirección en el plano horizontal del personaje
        Vector3 projection = Vector3.ProjectOnPlane(direction, Vector3.up);
        Debug.Log("DETECCION 5");
        // Obtiene el ángulo en relación con el frente del personaje
        float angle = Vector3.SignedAngle(PERSONAJE.transform.forward, projection, Vector3.up);
        Debug.Log("DETECCION 6");
        // Determina el lado de la colisión basado en el ángulo
        if (angle > 0)
        {
            Debug.Log("La mano colisionó desde el lado derecho.");
        }
        else
        {
            Debug.Log("La mano colisionó desde el lado izquierdo.");
        }
    }
}