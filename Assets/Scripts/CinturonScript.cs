using UnityEngine;

public class RotateAndFloat : MonoBehaviour
{
    // Velocidades públicas para ajustar desde el Inspector
    public float rotationSpeed = 100f; // Velocidad de rotación
    public float floatSpeed = 2f;      // Velocidad de subir y bajar
    public float floatHeight = 2f;     // Altura máxima a la que sube el objeto

    private float originalY;  // Posición original en el eje Y
    private bool goingUp = true;  // Para controlar la dirección de movimiento

    void Start()
    {
        // Almacenar la posición Y inicial del objeto
        originalY = transform.position.y;
    }

    void Update()
    {
        // Rotar el objeto alrededor del eje Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Movimiento de subir y bajar
        Vector3 position = transform.position;

        if (goingUp)
        {
            position.y += floatSpeed * Time.deltaTime;
            if (position.y >= originalY + floatHeight)
            {
                goingUp = false;  // Cambiar dirección cuando alcance la altura máxima
            }
        }
        else
        {
            position.y -= floatSpeed * Time.deltaTime;
            if (position.y <= originalY)
            {
                goingUp = true;  // Cambiar dirección cuando alcance la altura original
            }
        }

        // Aplicar la nueva posición
        transform.position = position;
    }
}