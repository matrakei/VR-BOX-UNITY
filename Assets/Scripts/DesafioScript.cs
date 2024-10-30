using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using TMPro;
using System;

public class DesafioScript : MonoBehaviour
{
    public GameObject Jero;
    public GameObject AnilloPreFab;
    static GameObject DERECHA;
    static GameObject IZQUIERDA;
    static GameObject FRENTE;
    static GameObject IZQUIERDAABAJO;
    static GameObject DERECHAABAJO;
    static GameObject CIRCULODERECHA;
    static GameObject CIRCULOIZQUIERDA;
    static GameObject CIRCULOFRENTE;
    static GameObject CIRCULOIZQUIERDAABAJO;
    static GameObject CIRCULODERECHAABAJO;
    GameObject Circle;
    public bool Termino = false;
    public float puntaje = 0f;
    GameObject ParteCuerpo;
    public float maxScaleSpeed = 5f;
    public float scaleSpeed = 1f;
    public float increaseAmount = 0.05f;
    bool IsActiveCircle = false;
    GameObject[] PartesCuerpo;
    int random;
    public TMP_Text TXT_Puntaje;
    public float duracion = 10f; // Duración del temporizador en segundos
    private float tiempoRestante;
    private bool temporizadorActivo = false;
    private Dictionary<GameObject, GameObject> CirculoDict;
    // Start is called before the first frame update
    void Awake()
    {
        DERECHA = GameObject.Find("DERECHA");
        IZQUIERDA = GameObject.Find("IZQUIERDA");
        FRENTE = GameObject.Find("FRENTE");
        IZQUIERDAABAJO = GameObject.Find("IZQUIERDA ABAJO");
        DERECHAABAJO = GameObject.Find("DERECHA ABAJO");
        CIRCULODERECHA = GameObject.Find("CIRCULO DERECHA");
        CIRCULOIZQUIERDA = GameObject.Find("CIRCULO IZQUIERDA");
        CIRCULOFRENTE = GameObject.Find("CIRCULO FRENTE");
        CIRCULOIZQUIERDAABAJO = GameObject.Find("CIRCULO IZQUIERDA ABAJO");
        CIRCULODERECHAABAJO = GameObject.Find("CIRCULO DERECHA ABAJO");
        PartesCuerpo = new GameObject[] {DERECHA, IZQUIERDA, FRENTE, IZQUIERDAABAJO, DERECHAABAJO};
        CirculoDict = new Dictionary<GameObject, GameObject>()
    {
        {DERECHA, CIRCULODERECHA },
        {IZQUIERDA, CIRCULOIZQUIERDA },
        {FRENTE, CIRCULOFRENTE },
        {IZQUIERDAABAJO, CIRCULOIZQUIERDAABAJO },
        {DERECHAABAJO, CIRCULODERECHAABAJO }
    };
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && IsActiveCircle)
        {
            DetectoColision(ParteCuerpo);
        }
        if (!IsActiveCircle && !Termino)
        {
            AumentarScaleSpeed();
            CrearAnillo();
        }
    }
    public void PerdioVida()
    {
        //pierde vida
        Debug.Log("Perdiste 2");
        Destroy(Circle.gameObject);
        Termino = true;
        GameManager.Instance.dead = true;
        Destroy(Jero.gameObject);
        Debug.Log("Puntaje Reiniciado");
        puntaje = 0;
        
    }

    void CrearAnillo()
    {
        IsActiveCircle = true;
        random = UnityEngine.Random.Range(0, PartesCuerpo.Length);
        ParteCuerpo = PartesCuerpo[random];
        Circle = Instantiate(AnilloPreFab, CirculoDict[PartesCuerpo[random]].transform.position, CirculoDict[PartesCuerpo[random]].transform.rotation, PartesCuerpo[random].transform);
        Circle.transform.localScale = CirculoDict[PartesCuerpo[random]].transform.localScale;
        //le doy la velocidad y le asigno el propio script de desafio
        Circle.GetComponent<AnilloScript>().speed = scaleSpeed;
        Circle.GetComponent<AnilloScript>().desafioScript = this;
    }

    public void DetectoColision(GameObject parte)
    {
        if (parte == ParteCuerpo)
        {
            //sigue jugando
            Destroy(Circle.gameObject);
            IsActiveCircle = false;
            puntaje += 100;
            TXT_Puntaje.text = puntaje.ToString();
            Debug.Log("Puntaje establecido");
        }
    }
    public void AumentarScaleSpeed()
    {
        if (scaleSpeed < maxScaleSpeed)
        scaleSpeed += increaseAmount;
    }

    public void IniciarTemporizador()
    {
        if (!temporizadorActivo)
        {
            tiempoRestante = duracion;
            temporizadorActivo = true;
            StartCoroutine(TemporizadorCoroutine());
        }
    }

    // Detiene el temporizador
    public void DetenerTemporizador()
    {
        if (temporizadorActivo)
        {
            temporizadorActivo = false;
            StopCoroutine(TemporizadorCoroutine());
            Debug.Log("Temporizador detenido");
        }
    }
    private void Start()
    {
        IniciarTemporizador();
        TXT_Puntaje.text = puntaje.ToString();
    }

    // La función que se ejecuta cuando el temporizador llega a 60 segundos
    private void RealizarAccionFinal()
    {
        PerdioVida();
    }

    // Coroutine para el temporizador
    private IEnumerator TemporizadorCoroutine()
    {
        while (temporizadorActivo && tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            yield return null; // Espera al siguiente frame
        }

        if (tiempoRestante <= 0 && temporizadorActivo)
        {
            RealizarAccionFinal();
            IsActiveCircle = false;
            temporizadorActivo = false;
        }
    }
}
