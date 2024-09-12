using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesScript : MonoBehaviour
{
    public AudioClip CROWD;
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Boton Jugar")
        {
            GameManager.Instance.ChangeScene("SampleScene");
            SoundManager.Instance.PlayMusic(CROWD);
        }
    }
}
