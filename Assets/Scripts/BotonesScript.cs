using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesScript : MonoBehaviour
{
    public AudioClip CROWD;
    public GameObject[] botonesGuantes;
    GameObject playButton;
    GameObject GuantesButton;
    private string previousScene;
    private void Start()
    {

    }
    private void Awake()
    {
        playButton = GameObject.Find("Boton Jugar");
        GuantesButton = GameObject.Find("Guantes Button");
        if (SceneManager.GetActiveScene().name == "Menu Inicio")
        {
            ActDiact(playButton, false);
            ActDiact(GuantesButton, false);
            StartCoroutine(WaitToActivate(10));
            foreach (GameObject boton in botonesGuantes)
            {
                ActDiact(boton, false);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Menu Past Inicio")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            foreach (GameObject boton in botonesGuantes)
            {
                ActDiact(boton, false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "ExitBox")
        {
            foreach (GameObject boton in botonesGuantes)
            {
                colide(boton);
            }
        }
    }
    private void Update()
    {
        if (GameManager.Instance.dead)
        {
            StartCoroutine(WaitSeconds(3));
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
            foreach (GameObject boton in botonesGuantes)
            {
                ActDiact(boton, true);
            }
            foreach (GameObject boton in botonesGuantes)
            {
                UnColide(boton);
            }

        }
        if (gameObject.name == "Guante Normal")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            foreach (GameObject boton in botonesGuantes)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes)
            {
                UnColide(boton);
            }
            GameManager.Instance.GuantesNormal(true);
        }
        if (gameObject.name == "Guante Variante")
        {
            ActDiact(playButton, true);
            ActDiact(GuantesButton, true);
            foreach (GameObject boton in botonesGuantes)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes)
            {
                UnColide(boton);
            }
            GameManager.Instance.GuantesNormal(false);
        }
    }
    IEnumerator WaitToActivate(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ActDiact(playButton, true);
        ActDiact(GuantesButton, true);
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
