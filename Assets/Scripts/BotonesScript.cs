using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesScript : MonoBehaviour
{
    bool waiting = true;
    public AudioClip CROWD;
    private void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(WaitToActivate(10));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!waiting)
        {
            if (gameObject.name == "Boton Jugar")
            {
                GameManager.Instance.ChangeScene("Level");
                SoundManager.Instance.PlayMusic(CROWD);
            }
        }
    }
    IEnumerator WaitToActivate(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        waiting = false;
    }
}
