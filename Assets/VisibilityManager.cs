using UnityEngine;
using System.Collections.Generic; // Necesario para usar listas.

public class VisibilityManager : MonoBehaviour
{
    public Camera mainCamera; // Asigna tu cámara desde el Inspector.
    private List<Renderer> espectadorRenderers = new List<Renderer>(); // Lista para almacenar los renderers de los espectadores.
    private List<Collider> espectadorColliders = new List<Collider>(); // Lista para almacenar los colliders de los espectadores.

    private void Awake()
    {
        // Obtén la cámara si no está asignada.
        if (mainCamera == null)
        {
            mainCamera = GetComponent<Camera>();
        }

        // Encuentra todos los renderers y colliders con la etiqueta "Espectador" al inicio.
        GameObject[] espectadors = GameObject.FindGameObjectsWithTag("Espectador");
        foreach (GameObject espectador in espectadors)
        {
            Renderer renderer = espectador.GetComponent<Renderer>();
            Collider collider = espectador.GetComponent<Collider>();

            if (renderer != null)
            {
                espectadorRenderers.Add(renderer);
            }

            if (collider != null)
            {
                espectadorColliders.Add(collider);
            }
        }
    }

    void Update()
    {
        // Recorre los renderers en la lista para verificar si están en el frustum de la cámara.
        for (int i = 0; i < espectadorRenderers.Count; i++)
        {
            Renderer renderer = espectadorRenderers[i];
            Collider collider = espectadorColliders[i];

            if (renderer != null) // Verifica que el renderer no sea nulo.
            {
                // Verificar si el objeto está dentro del frustum de la cámara.
                if (IsVisibleFrom(renderer, mainCamera))
                {
                    // Activa el Renderer y Collider si está visible, para que sea interactivo y visible.
                    renderer.enabled = true;
                    if (collider != null) collider.enabled = true;
                }
                else
                {
                    // Desactiva solo el Renderer y el Collider si no está visible, para ocultar pero mantener la lógica.
                    renderer.enabled = false;
                    if (collider != null) collider.enabled = false;
                }
            }
        }
    }

    // Función para verificar si el objeto es visible desde la cámara.
    bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}