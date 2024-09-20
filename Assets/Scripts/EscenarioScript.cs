using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EscenarioScript : MonoBehaviour
{
    public float velocidad;
    public float duracionMovimiento;

    private void Awake()
    {

    }
    void Start()
    {
        if(gameObject.tag != "Espectador")
        {
            StartCoroutine(MoverYDetenerDespuesDeTiempo(duracionMovimiento));
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
