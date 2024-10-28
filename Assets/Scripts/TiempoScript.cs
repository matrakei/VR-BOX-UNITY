using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.Tracing;
using UnityEngine.SceneManagement;

public class TiempoScript : MonoBehaviour
{
    public TMP_Text relojText;
    float tiempoTotal;
    bool estabaMuerto;
    private void Start()
    {
        estabaMuerto = GameManager.Instance.dead;
        relojText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        if (GameManager.Instance.dead != estabaMuerto)
        {
            if (!GameManager.Instance.dead)
            {
                tiempoTotal = 0;
            }
            estabaMuerto = GameManager.Instance.dead;
        }
        if (!GameManager.Instance.dead)
        {
            tiempoTotal += Time.deltaTime;
        }
        if (SceneManager.GetActiveScene().name != "Menu Inicio" && SceneManager.GetActiveScene().name != "Menu Past Inicio")
        {
            int minutos = Mathf.FloorToInt(tiempoTotal / 60);
            int segundos = Mathf.FloorToInt(tiempoTotal % 60);
            relojText.text = string.Format("{0:D2}:{1:D2}", minutos, segundos);
        }
    }
}
