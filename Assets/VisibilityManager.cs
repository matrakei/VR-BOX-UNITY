using UnityEngine;
using System.Collections.Generic; // Necesario para usar listas.

public class VisibilityManager : MonoBehaviour
{
    public Camera mainCamera; // Asigna tu cámara desde el Inspector.
    private List<Renderer> espectadorRenderers = new List<Renderer>(); // Lista para almacenar los renderers de los espectadores.
    public float buffer = 0.1f; // Factor de expansión del frustum. 0.1f es un 10% extra.

    private void Awake()
    {
        // Encuentra todos los renderers y colliders con la etiqueta "Espectador" al inicio.
        GameObject[] espectadors = GameObject.FindGameObjectsWithTag("Espectador");
        foreach (GameObject espectador in espectadors)
        {
            Renderer renderer = espectador.GetComponent<Renderer>();

            if (renderer != null)
            {
                espectadorRenderers.Add(renderer);
            }
        }
    }

    void Update()
    {
        // Recorre los renderers en la lista para verificar si están en el frustum de la cámara.
        for (int i = 0; i < espectadorRenderers.Count; i++)
        {
            Renderer renderer = espectadorRenderers[i];

            if (renderer != null) // Verifica que el renderer no sea nulo.
            {
                // Verificar si el objeto está dentro del frustum de la cámara expandido con buffer.
                if (IsVisibleFrom(renderer, mainCamera))
                {
                    // Activa el Renderer si está visible, para que sea interactivo y visible.
                    renderer.enabled = true;
                }
                else
                {
                    // Desactiva solo el Renderer si no está visible, para ocultar pero mantener la lógica.
                    renderer.enabled = false;
                }
            }
        }
    }

    // Función para verificar si el objeto es visible desde la cámara con un buffer.
    bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

        // Expandimos el frustum aplicando el buffer a cada plano del frustum.
        for (int i = 0; i < planes.Length; i++)
        {
            planes[i].distance += buffer; // Aplicamos un pequeño desplazamiento en la distancia del plano.
        }

        // Verificamos si el bounding box del objeto está dentro de los planos del frustum.
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}