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
    private void Awake()
    {
        playButton = GameObject.Find("Boton Jugar");
        GuantesButton = GameObject.Find("Guantes Button");
        if (SceneManager.GetActiveScene().name == "Menu Inicio")
        {
            playButton.GetComponent<MeshRenderer>().enabled = false;
            GuantesButton.GetComponent<MeshRenderer>().enabled = false;
            if (gameObject == playButton)
            {
                playButton.GetComponent<MeshCollider>().enabled = false;
            }
            else if (gameObject == GuantesButton)
            {
                GuantesButton.GetComponent<BoxCollider>().enabled = false;
            }
            StartCoroutine(WaitToActivate(10));
            foreach (GameObject boton in botonesGuantes)
            {
                ActDiact(boton, false);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Menu Past Inicio")
        {
            playButton.SetActive(true);
            GuantesButton.SetActive(true);
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
                boton.layer = 0;
                GuantesButton.layer = 0;
                playButton.layer = 0;
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
            playButton.SetActive(false);
            GuantesButton.SetActive(false);
            foreach (GameObject boton in botonesGuantes)
            {
                ActDiact(boton, true);
            }
            foreach (GameObject boton in botonesGuantes)
            {
                boton.layer = 6;
                GuantesButton.layer = 6;
                playButton.layer = 6;
            }

        }
        if (gameObject.name == "Guante Normal")
        {
            playButton.SetActive(true);
            GuantesButton.SetActive(true);
            foreach (GameObject boton in botonesGuantes)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes)
            {
                boton.layer = 6;
                GuantesButton.layer = 6;
                playButton.layer = 6;
            }
            GameManager.Instance.GuantesNormal(true);
        }
        if (gameObject.name == "Guante Variante")
        {
            playButton.SetActive(true);
            GuantesButton.SetActive(true);
            foreach (GameObject boton in botonesGuantes)
            {
                ActDiact(boton, false);
            }
            foreach (GameObject boton in botonesGuantes)
            {
                boton.layer = 6;
                GuantesButton.layer = 6;
                playButton.layer = 6;
            }
            GameManager.Instance.GuantesNormal(false);
        }
    }
    IEnumerator WaitToActivate(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        playButton.GetComponent<MeshRenderer>().enabled = true;
        GuantesButton.GetComponent<MeshRenderer>().enabled = true;
        if (gameObject == playButton)
        {
            playButton.GetComponent<MeshCollider>().enabled = true;
        }
        else if (gameObject == GuantesButton)
        {
            GuantesButton.GetComponent<BoxCollider>().enabled = true;
        }
    }
    IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    void ActDiact(GameObject objeto, bool thebool)
    {
        objeto.GetComponent<MeshRenderer>().enabled = thebool;
        objeto.GetComponent<BoxCollider>().enabled = thebool;
    }
}
