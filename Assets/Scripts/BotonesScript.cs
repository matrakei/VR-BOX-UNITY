using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesScript : MonoBehaviour
{
    public AudioClip CROWD;
    GameObject playButton;
    public GameObject[] botonesGuantes;
    GameObject GuantesButton;
    private void Awake()
    {
        playButton = GameObject.Find("Boton Jugar");
        GuantesButton = GameObject.Find("Guantes Button");
        if (SceneManager.GetActiveScene().name == "Menu Inicio" && gameObject.name == "Boton Jugar")
        {
            playButton.GetComponent<MeshRenderer>().enabled = false;
            playButton.GetComponent<MeshCollider>().enabled = false;
            StartCoroutine(WaitToActivate(10));
        }
        if (SceneManager.GetActiveScene().name == "Menu Inicio" && gameObject.name == "Boton Jugar")
        {
            GuantesButton.GetComponent<MeshRenderer>().enabled = false;
            GuantesButton.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(WaitToActivate(10));
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

        if (gameObject.name == "Play Again Button")
        {
            GameManager.Instance.ChangeScene("Level");
            Debug.Log("Play Again");
            GameManager.Instance.dead = false;
        }
        if (gameObject.name == "Boton Salir")
        {
            Debug.Log("Salio");
            Application.Quit();
        }
        if (gameObject.name == "Guantes Button")
        {
            playButton.SetActive(false);
            foreach (GameObject boton in botonesGuantes)
            {
                boton.SetActive(true);
            }
        }
        if (gameObject.name == "Guante Normal")
        {
            playButton.SetActive(true);
            foreach (GameObject boton in botonesGuantes)
            {
                boton.SetActive(false);
            }
            //logica para cambiar el guante
        }
        if (gameObject.name == "Guante Variante")
        {
            playButton.SetActive(true);
            foreach (GameObject boton in botonesGuantes)
            {
                boton.SetActive(false);
            }
            //logica para cambiar el guante
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
        if (gameObject == GuantesButton)
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
}
