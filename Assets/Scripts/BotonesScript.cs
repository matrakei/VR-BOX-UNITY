using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Boton Jugar")
        {
            GameManager.Instance.ChangeScene("SampleScene");
        }
    }
}