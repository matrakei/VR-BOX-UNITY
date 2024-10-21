using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioScript : MonoBehaviour
{
    GameObject DERECHA;
    GameObject IZQUIERDA;
    GameObject FRENTE;
    GameObject IZQUIERDAABAJO;
    GameObject DERECHAABAJO;
    GameObject[] PartesCuerpo;
    int random;

    // Start is called before the first frame update
    void Awake()
    {
        DERECHA = GameObject.Find("DERECHA");
        IZQUIERDA = GameObject.Find("IZQUIERDA");
        FRENTE = GameObject.Find("FRENTE");
        IZQUIERDAABAJO = GameObject.Find("IZQUIERDA ABAJO");
        DERECHAABAJO = GameObject.Find("DERECHA ABAJO");
        PartesCuerpo = new GameObject[] {DERECHA, IZQUIERDA, FRENTE, IZQUIERDAABAJO, DERECHAABAJO};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
