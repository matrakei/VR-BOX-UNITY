
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

public class PeleaController : MonoBehaviour
    {
        public Animator JeroAnimations;
        public HealthBarScript healthbarNPC; // Agarrar barra de salud ya hecha

        // Clase para representar una secuencia de acciones del NPC

        [System.Serializable]
        public class SecuenciaJero
    {
            public string animacionJero;
            public float tiempoEspera; // Tiempo de espera antes de la siguiente acción
            public int dano; // Daño que inflige al jugador
        }

        // Lista de secuencias predefinidas para el NPC
        public List<SecuenciaJero> secuenciasJero = new List<SecuenciaJero>();

        private int indiceActual = 0; // Índice de la secuencia actual

        private void Start()
        {
            // Iniciar la secuencia de la pelea del NPC
            StartCoroutine(EjecutarSecuenciaNPC());
        }

        private IEnumerator EjecutarSecuenciaNPC()
        {
            while (indiceActual < secuenciasJero.Count && healthbarNPC.hp > 0)
            {
            // Obtener la secuencia actual
            SecuenciaJero secuenciaActual = secuenciasJero[indiceActual];

                // Ejecutar la animación del NPC
                JeroAnimations.SetTrigger(secuenciaActual.animacionJero);

                // Aplicar daño al jugador (si corresponde)
                AplicarDanio(secuenciaActual.dano);

                // Esperar el tiempo especificado antes de pasar a la siguiente acción
                yield return new WaitForSeconds(secuenciaActual.tiempoEspera);

                // Pasar a la siguiente secuencia
                indiceActual++;
            }

            // Acciones al finalizar la secuencia (cuando se acaben las secuencias o la salud del NPC llegue a 0)
            if (healthbarNPC.hp <= 0)
            {
                Debug.Log("El NPC ha sido derrotado.");
            }
            else
            {
                Debug.Log("Secuencia de combate del NPC completada.");
            }
        }

        private void AplicarDanio(int dano)
        {
            // Aquí puedes aplicar daño al jugador (si el NPC está atacando)
            if (dano > 0)
            {
                // Accede a la barra de salud del jugador y resta el daño
                // Ejemplo: healthbarJugador.hp -= dano;
                Debug.Log("El jugador recibió " + dano + " de daño.");
            }
        }

        // Método de detección de golpes entrantes
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("GolpeJugador"))
            {
                healthbarNPC.hp -= 10; // Reducir la salud del NPC si recibe un golpe
            }
        }
    }