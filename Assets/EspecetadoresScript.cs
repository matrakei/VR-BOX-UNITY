using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EspecetadoresScript : MonoBehaviour
{
    public float minHeight = 0.5f; // Altura m�nima a la que bajar� el c�rculo
    public float maxHeight = 2.0f; // Altura m�xima a la que subir� el c�rculo
    public float speedMax = 1.0f; // Velocidad del movimiento
    public float speedMin = 0.5f; // Velocidad m�nima del movimiento
    public float speed;
    public float height;
    //falta modificar la lista de colores si es que hace falta
    Color[] pastelColors = new Color[]
{
        new Color(0.82f, 0.95f, 0.76f), // Verde claro
        new Color(0.87f, 0.93f, 0.74f), // Lima suave
        new Color(0.89f, 0.94f, 0.81f), // Verde menta suave
        new Color(0.94f, 0.90f, 0.74f), // Amarillo pastel
        new Color(0.96f, 0.94f, 0.76f), // Amarillo vainilla
        new Color(0.94f, 0.84f, 0.77f), // Melocot�n suave
        new Color(0.95f, 0.88f, 0.79f), // Salm�n suave
        new Color(0.98f, 0.92f, 0.82f), // Naranja pastel claro
        new Color(0.96f, 0.79f, 0.76f), // Coral suave
        new Color(0.90f, 0.80f, 0.77f), // Rosa palo
        new Color(0.93f, 0.79f, 0.90f), // Lila suave
        new Color(0.94f, 0.85f, 0.92f), // Rosa pastel suave
        new Color(0.86f, 0.82f, 0.97f), // Lavanda claro
        new Color(0.83f, 0.85f, 0.97f), // Azul lavanda claro
        new Color(0.76f, 0.88f, 0.97f), // Celeste pastel
        new Color(0.77f, 0.91f, 0.93f), // Cian claro pastel
        new Color(0.75f, 0.92f, 0.89f), // Aguamarina suave
        new Color(0.81f, 0.92f, 0.89f), // Verde agua suave
        new Color(0.84f, 0.93f, 0.85f), // Verde musgo suave
        new Color(0.89f, 0.96f, 0.88f), // Verde
};
    Color[] vibrantColors = new Color[]
{
    new Color(0.13f, 0.55f, 0.13f), // Verde oscuro
    new Color(0.18f, 0.80f, 0.44f), // Verde esmeralda
    new Color(0.24f, 0.70f, 0.44f), // Verde selva
    new Color(0.25f, 0.88f, 0.82f), // Turquesa
    new Color(0.00f, 0.75f, 1.00f), // Cian
    new Color(0.00f, 0.50f, 1.00f), // Azul brillante
    new Color(0.53f, 0.81f, 0.98f), // Azul cielo
    new Color(0.25f, 0.41f, 0.88f), // Azul real
    new Color(0.29f, 0.00f, 0.51f), // �ndigo
    new Color(0.50f, 0.00f, 0.50f), // P�rpura
    new Color(0.54f, 0.17f, 0.89f), // Violeta
    new Color(0.67f, 0.31f, 0.32f), // Marr�n terroso
    new Color(0.60f, 0.40f, 0.20f), // Ocre
    new Color(0.82f, 0.70f, 0.23f), // Dorado
    new Color(1.00f, 0.84f, 0.00f), // Amarillo oro
    new Color(0.85f, 0.65f, 0.13f), // Amarillo mostaza
    new Color(1.00f, 0.65f, 0.00f), // Naranja fuerte
    new Color(1.00f, 0.55f, 0.00f), // Naranja quemado
    new Color(0.93f, 0.51f, 0.93f), // Violeta suave
    new Color(0.50f, 0.50f, 0.00f), // Oliva
};

    int color = 0;
    public Renderer renderer;

    private Vector3 initialPosition; // Guardar la posici�n original del c�rculo
    private void Update()
    {

    }
    void Start()
    {
        color = Random.Range(0, vibrantColors.Length);
        // Asignar un color aleatorio al c�rculo
        renderer.material.color = vibrantColors[color];
        if (SceneManager.GetActiveScene().name != "Level")
        {
            // Iniciar el movimiento c�clico de subida y bajada constante
            StartCoroutine(MoveCircleConstantly());
        }
    }
    IEnumerator MoveCircleConstantly()
    {
        //if (SceneManager.GetActiveScene().name == "Menu Inicio")
        //{
        //    yield return new WaitForSeconds(10);
        //}
        initialPosition = transform.localPosition;
        while (true)
        {
            speed = Random.Range(speedMin, speedMax); // Velocidad aleatoria
            height = Random.Range(minHeight, maxHeight); // Altura aleatoria
                                                         // Subir progresivamente a la altura m�xima
            yield return StartCoroutine(MoveToPosition(new Vector3(initialPosition.x, initialPosition.y + height, initialPosition.z)));

            // Bajar progresivamente a la altura m�nima
            yield return StartCoroutine(MoveToPosition(new Vector3(initialPosition.x, initialPosition.y, initialPosition.z)));
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        // Movimiento progresivo hacia la posici�n de destino
        while (Vector3.Distance(transform.localPosition, targetPosition) > 0.01f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed);
            yield return null; // Esperar al siguiente frame
        }

        // Asegurarse de que la posici�n final sea exacta
        transform.localPosition = targetPosition;
    }
}