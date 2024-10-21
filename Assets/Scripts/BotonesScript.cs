using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesScript : MonoBehaviour
{
    public AudioClip CROWD;
    public GameObject[] botonesGuantes1;
    public GameObject[] botonesGuantes2;
    GameObject playButton;
    GameObject CambiarButton;
    GameObject GuantesButton;
    private string previousScene;
    bool uno = true;
    bool waited = false;

    public float speed = 23f;  // Velocidad del movimiento
    private Vector3 initialPosition;  // Posición inicial del objeto
    private Vector3 targetPosition;   // Posición destino basada en la velocidad y tiempo
    public float moveDuration = 5f;  // Duración del movimiento en segundos
    private float elapsedTime = 0f;// Tiempo transcurrido
    private void Start()
    {

    }
    private void Awake()
    {
        // Calcular la distancia de movimiento basada en la velocidad y el tiempo
        float distance = speed * moveDuration;

        // Mover el objeto en sentido contrario según su nombre
        if (gameObject.name == "Play Again Button")
        {
            initialPosition = transform.position;
            targetPosition = initialPosition - new Vector3(0, 0, distance);  // Retroceder en Z
            transform.position = targetPosition;
        }
        else if (gameObject.name == "Congrats Text")
        {
            initialPosition = transform.position;
            targetPosition = initialPosition - new Vector3(distance, 0, 0);  // Retroceder en X
            transform.position = targetPosition;
        }
        else if (gameObject.name == "Boton Salir" && SceneManager.GetActiveScene().name != "Bolsa")
        {
            initialPosition = transform.position;
            targetPosition = initialPosition + new Vector3(0, 0, distance);  // Avanzar en Z
            transform.position = targetPosition;
        }
        playButton = GameObject.Find("Boton Jugar");
        GuantesButton = GameObject.Find("Guantes Button");
        CambiarButton = GameObject.Find("Cambiar");
        if (SceneManager.GetActiveScene().name == "Menu Inicio")
        {
            ActDiact(playButton, false);
            ActDiact(GuantesButton, false);
            ActDiact(CambiarButton, false);
            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes2)
            {
                ActDiact(boton, false);
            }
            if(!waited)
            StartCoroutine(WaitToActivate(10));
        }
        else if (SceneManager.GetActiveScene().name == "Menu Past Inicio")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, false);                          
            }
            foreach (GameObject boton in botonesGuantes2)
            {
                ActDiact(boton, false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "ExitBox2")
        {
            playButton.layer = 0;
            GuantesButton.layer = 0;
        }
        if (gameObject.name == "ExitBox")
        {
            foreach (GameObject boton in botonesGuantes1)
            {
                colide(boton);
            }
            foreach (GameObject boton in botonesGuantes2)
            {
                colide(boton);
            }
        }
    }
    private void Update()
    {
        if (GameManager.Instance.dead)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime <= moveDuration)
            {
                // Lerp para suavizar el movimiento hacia la posición objetivo en 5 segundos
                transform.position = Vector3.Lerp(targetPosition, initialPosition, elapsedTime / moveDuration);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Boton Jugar")
        {
            GameManager.Instance.ChangeScene("Level");
            SoundManager.Instance.PlayMusic(CROWD);
        }
        else if (gameObject.name == "Play Again Button")
        {
            Debug.Log("Play Again");
            GameManager.Instance.ChangeScene("Level");
            GameManager.Instance.dead = false;
        }
        else if (gameObject.name == "Boton Salir")
        {
            Debug.Log("Salio");
            GameManager.Instance.ChangeScene("Menu Past Inicio");
            GameManager.Instance.dead = false;
        }
        else if (gameObject.name == "Guantes Button")
        {
            ActDiact(playButton, false);
            ActDiact(GuantesButton, false);
            ActDiact(CambiarButton, true);
            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, true);
            }
            foreach (GameObject boton in botonesGuantes1)
            {
                UnColide(boton);
            }
        }
        else if (gameObject.name == "Cambiar")
        {
            if (uno)
            {
                foreach (GameObject boton in botonesGuantes1)
                {
                    ActDiact(boton, false);
                }
                foreach (GameObject boton in botonesGuantes2)
                {
                    ActDiact(boton, true);  
                }
                foreach (GameObject boton in botonesGuantes2)
                {
                    UnColide(boton);
                }
            }
            else if (!uno)
            {
                foreach (GameObject boton in botonesGuantes2)
                {
                    ActDiact(boton, false);
                }
                foreach (GameObject boton in botonesGuantes1)
                {
                    ActDiact(boton, true);
                }
                foreach (GameObject boton in botonesGuantes1)
                {
                    UnColide(boton);
                }
            }
            uno = !uno;
        }
        else if (gameObject.name == "Guante Normal")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes2)
            {
                ActDiact(boton, false);
            }
            playButton.layer = 6;
            GuantesButton.layer = 6;
            GameManager.Instance.Guantes(1);
        }
        else if (gameObject.name == "Guante Variante")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes2)
            {
                ActDiact(boton, false);
            }
            playButton.layer = 6;
            GuantesButton.layer = 6;
            GameManager.Instance.Guantes(2);
        }
        else if (gameObject.name == "Guante Estrellas")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes2)
            {
                ActDiact(boton, false);
            }
            playButton.layer = 6;
            GuantesButton.layer = 6;
            GameManager.Instance.Guantes(3);
        }
        else if (gameObject.name == "Guante Supreme")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes2)
            {
                ActDiact(boton, false);
            }
            playButton.layer = 6;
            GuantesButton.layer = 6;
            GameManager.Instance.Guantes(4);
        }
    }
    IEnumerator WaitToActivate(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ActDiact(playButton, true);
        ActDiact(GuantesButton, true);
        waited = true;
    }
    IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ActDiact(gameObject, true);
    }
    void ActDiact(GameObject objeto, bool thebool)
    {
        if (objeto.GetComponent<MeshRenderer>() != null)
            objeto.GetComponent<MeshRenderer>().enabled = thebool;
        if (objeto.GetComponent<MeshCollider>() != null)
            objeto.GetComponent<MeshCollider>().enabled = thebool;
        if (objeto.GetComponent<BoxCollider>() != null)
            objeto.GetComponent<BoxCollider>().enabled = thebool;
    }
    private void UnColide(GameObject boton)
    {
        boton.layer = 6;
        GuantesButton.layer = 6;
        playButton.layer = 6;
    }

    private void colide(GameObject boton)
    {
        boton.layer = 0;
        GuantesButton.layer = 0;
        playButton.layer = 0;
    }
}
