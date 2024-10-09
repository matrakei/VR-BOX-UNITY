using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento

    void Update()
    {
        // Movimiento vertical con Z y X
        float moveY = 0f;

        if (Input.GetKey(KeyCode.Z))
        {
            moveY = 1f;  // Mover hacia arriba
        }
        else if (Input.GetKey(KeyCode.X))
        {
            moveY = -1f;  // Mover hacia abajo
        }
        // Obtener entrada del usuario
        float moveX = Input.GetAxis("Horizontal");  // A y D o flechas izquierda/derecha
        float moveZ = Input.GetAxis("Vertical");    // W y S o flechas arriba/abajo

        // Crear un vector de movimiento basado en la entrada
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        Vector3 moves = new Vector3(0, moveY, 0) * moveSpeed * Time.deltaTime;

        // Aplicar el movimiento al GameObject
        transform.Translate(moves, Space.World);
        // Aplicar el movimiento al GameObject
        transform.Translate(move, Space.World);
    }
}

