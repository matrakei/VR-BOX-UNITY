using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesScript : MonoBehaviour
{
    bool MovioDespuesDeMuerte = false;
    public AudioClip CROWD;
    public GameObject[] botonesGuantes1;
    public GameObject[] botonesGuantes2;
    GameObject playButton;
    GameObject CambiarButton;
    GameObject GuantesButton;
    GameObject PracticaButton;
    GameObject DesafioButton;
    private string previousScene;
    bool uno = true;
    bool waited = false;

    public float speed = 23f;  // Velocidad del movimiento
    private Vector3 initialPosition;  // Posici�n inicial del objeto
    private Vector3 targetPosition;   // Posici�n destino basada en la velocidad y tiempo
    public float moveDuration = 5f;  // Duraci�n del movimiento en segundos
    private float elapsedTime = 0f;// Tiempo transcurrido
    private void Start()
    {

    }
    private void Awake()
    {
        // Calcular la distancia de movimiento basada en la velocidad y el tiempo
        float distance = speed * moveDuration;

        // Mover el objeto en sentido contrario seg�n su nombre
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
        PracticaButton = GameObject.Find("Boton Practica");
        DesafioButton = GameObject.Find("Boton Desafio");
        if (SceneManager.GetActiveScene().name == "Menu Inicio")
        {
            ActDiact(playButton, false);
            ActDiact(GuantesButton, false);
            ActDiact(CambiarButton, false);
            ActDiact(PracticaButton, false);
            ActDiact(DesafioButton, false); 
            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes2)
            {
                ActDiact(boton, false);
            }
            if (!waited)
            {
                StartCoroutine(WaitToActivate(10));
            }
        }
        else if (SceneManager.GetActiveScene().name == "Menu Past Inicio")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            ActDiact(PracticaButton, true);
            ActDiact(DesafioButton, true);
            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, false);                          
            }
            foreach (GameObject boton in botonesGuantes2)
            {
                ActDiact(boton, false);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Desafio" && gameObject.name == "Play Again Button")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (gameObject.GetComponent<MeshCollider>() != null)
                gameObject.GetComponent<MeshCollider>().enabled = false;
            if (gameObject.GetComponent<BoxCollider>() != null)
                gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (SceneManager.GetActiveScene().name == "Desafio" && gameObject.name == "Boton Salir")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (gameObject.GetComponent<MeshCollider>() != null)
                gameObject.GetComponent<MeshCollider>().enabled = false;
            if (gameObject.GetComponent<BoxCollider>() != null)
                gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "ExitBox2")
        {
            CambiarButton.layer = 0;
            playButton.layer = 0;
            GuantesButton.layer = 0;
            PracticaButton.layer = 0;
            DesafioButton.layer = 0;
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
            CambiarButton.layer = 0;   
        }
    }
    private void Update()
    {
        if (GameManager.Instance.dead && !MovioDespuesDeMuerte)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime <= moveDuration)
            {
                // Lerp para suavizar el movimiento hacia la posici�n objetivo en 5 segundos
                transform.position = Vector3.Lerp(targetPosition, initialPosition, elapsedTime / moveDuration);
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                if (gameObject.GetComponent<MeshCollider>() != null)
                    gameObject.GetComponent<MeshCollider>().enabled = true;
                if (gameObject.GetComponent<BoxCollider>() != null)
                    gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                // Una vez que termine de mover los objetos
                MovioDespuesDeMuerte = true;
                elapsedTime = 0f; // Resetear elapsedTime a su valor predeterminado
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Boton Jugar")
        {
            GameManager.Instance.dead = false;
            MovioDespuesDeMuerte = false;
            GameManager.Instance.ChangeScene("Level");
            SoundManager.Instance.PlayMusic(CROWD);
        }
        else if (gameObject.name == "Play Again Button")
        {
            Debug.Log("Play Again");
            GameManager.Instance.dead = false;
            MovioDespuesDeMuerte = false;
            if (SceneManager.GetActiveScene().name == "Desafio")
            {
                GameManager.Instance.ChangeScene("Desafio");
            }
            else if (SceneManager.GetActiveScene().name == "Level")
            {
                GameManager.Instance.ChangeScene("Level");
            }
        }
        else if (gameObject.name == "Boton Salir")
        {
            Debug.Log("Salio");
            GameManager.Instance.dead = false;
            MovioDespuesDeMuerte = false;
            GameManager.Instance.ChangeScene("Menu Past Inicio");
        }
        else if (gameObject.name == "Boton Practica")
        {
            Debug.Log("Practica");
            GameManager.Instance.ChangeScene("Bolsa");
        }
        else if (gameObject.name == "Boton Desafio")
        {
            Debug.Log("Desafio");
            GameManager.Instance.dead = false;
            MovioDespuesDeMuerte = false;
            GameManager.Instance.ChangeScene("Desafio");
        }
        else if (gameObject.name == "Guantes Button")
        {
            ActDiact(playButton, false);
            ActDiact(GuantesButton, false);
            ActDiact(CambiarButton, true);
            ActDiact(PracticaButton, false);
            ActDiact(DesafioButton, false);

            foreach (GameObject boton in botonesGuantes1)
            {
                ActDiact(boton, true);
            }
            foreach (GameObject boton in botonesGuantes1)
            {
                UnColide(boton);
            }
            UnColide(CambiarButton);
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
                uno = !uno;
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
                uno = !uno;
            }
        }
        else if (gameObject.name == "Guante Normal")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            ActDiact(PracticaButton, true);
            ActDiact(DesafioButton, true);
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
            PracticaButton.layer = 6;
            DesafioButton.layer = 6;
            GameManager.Instance.Guantes(1);
        }
        else if (gameObject.name == "Guante Variante")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            ActDiact(PracticaButton, true);
            ActDiact(DesafioButton, true);
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
            PracticaButton.layer = 6;
            DesafioButton.layer = 6;
            GameManager.Instance.Guantes(2);
        }
        else if (gameObject.name == "Guante Estrellas")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            ActDiact(PracticaButton, true);
            ActDiact(DesafioButton, true);
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
            PracticaButton.layer = 6;
            DesafioButton.layer = 6;
            GameManager.Instance.Guantes(3);
        }
        else if (gameObject.name == "Guante Supreme")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            ActDiact(CambiarButton, false);
            ActDiact(PracticaButton, true);
            ActDiact(DesafioButton, true);
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
            PracticaButton.layer = 6;
            DesafioButton.layer = 6;
            GameManager.Instance.Guantes(4);
        }
    }
    
    IEnumerator WaitToActivate(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ActDiact(playButton, true);
        ActDiact(GuantesButton, true);
        ActDiact(CambiarButton, false);
        ActDiact(PracticaButton, true);
        ActDiact(DesafioButton, true);
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
        PracticaButton.layer = 6;
        DesafioButton.layer = 6;    
    }

    private void colide(GameObject boton)
    {
        boton.layer = 0;
        GuantesButton.layer = 0;
        playButton.layer = 0;
        PracticaButton.layer = 0;
        DesafioButton.layer = 0;
    }
}
