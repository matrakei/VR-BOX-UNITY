using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionColision : MonoBehaviour
{
    public GameObject sweatParticlesPrefab;  // Prefab de las partículas de sudor
    public float particleLifetime = 2.0f;    // Tiempo que duran las partículas antes de destruirs
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fist"))  // Asegúrate de que el puño tiene el tag "Fist"
        {
            // Obtener el punto de contacto aproximado usando la posición del otro objeto (puño)
            Vector3 contactPoint = other.ClosestPoint(transform.position);

            // Instanciar las partículas en el punto de contacto
            GameObject particles = Instantiate(sweatParticlesPrefab, contactPoint, Quaternion.identity);

            // Destruir las partículas después de un tiempo
            Destroy(particles, particleLifetime);
            Debug.Log("Particle generada");
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
            
    //    }
    //}
}


