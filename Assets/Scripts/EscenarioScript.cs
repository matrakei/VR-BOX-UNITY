using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenarioScript : MonoBehaviour
{
    public float velocidad;
    public float duracionMovimiento;
    public Light[] spotLights; // Arreglo para las 4 Spot Lights.
    public float startAngle = 30f; // Ángulo inicial del Spot Light.
    public float endAngle = 90f; // Ángulo final del Spot Light.
    public float duration = 10f; // Duración en segundos.
    private float elapsedTime = 0f;

    void Update()
    {
        // Si el tiempo transcurrido es menor que la duración, sigue ajustando los ángulos.
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Calcula el progreso (0 a 1) del tiempo transcurrido.
            float progress = elapsedTime / duration;

            // Interpola el ángulo de inicio a fin basado en el progreso.
            float currentAngle = Mathf.Lerp(startAngle, endAngle, progress);

            // Aplica el ángulo actual a todas las Spot Lights.
            foreach (Light spotLight in spotLights)
            {
                if (spotLight.type == LightType.Spot)
                {
                    spotLight.spotAngle = currentAngle;
                }
            }
        }
    }
    void Start()
    {
        if(gameObject.tag != "Espectador" && SceneManager.GetActiveScene().name == "Menu Inicio")
        {
            StartCoroutine(MoverYDetenerDespuesDeTiempo(duracionMovimiento));
            // Asegúrate de que las luces tengan el ángulo de inicio al principio.
            foreach (Light spotLight in spotLights)
            {
                if (spotLight.type == LightType.Spot)
                {
                    spotLight.spotAngle = startAngle;
                }
            }
        }
    }

    IEnumerator MoverYDetenerDespuesDeTiempo(float duracion)
    {
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracion)
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
    }
}
