using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colisionó con el puño");
        // Chequea si el objeto que colisionó es el puño
        if (collision.gameObject.CompareTag("GUANTES"))
        {
            DetectarLado(collision);
        }
    }

    private void DetectarLado(Collision collision)
    {
        // Obtén la posición del punto de contacto más cercano
        ContactPoint contactPoint = collision.GetContact(0);
        Debug.Log("Punto de contacto: " + contactPoint.point);

        // Calcula la dirección de la colisión
        Vector3 direction = contactPoint.point - gameObject.transform.position;
        Debug.Log(direction.sqrMagnitude);

        // Proyecta la dirección en el plano horizontal del personaje
        Vector3 projection = Vector3.ProjectOnPlane(direction, Vector3.up);
        Debug.Log(projection.sqrMagnitude);

        // Obtiene el ángulo en relación con el frente del personaje
        float angle = Vector3.SignedAngle(gameObject.transform.forward, projection, Vector3.up);
        Debug.Log(angle);

        // Determina el lado de la colisión basado en el ángulo
        if (angle > 0)
        {
            Debug.Log("La colisión provino del lado derecho.");
        }
        else
        {
            Debug.Log("La colisión provino del lado izquierdo.");
        }
    }
}
