using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioScript : MonoBehaviour
{
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
    GameObject ParteCuerpo;
    public float scaleSpeed;
    bool IsActiveCircle;
    GameObject[] PartesCuerpo;
    int random;
    Dictionary<GameObject, GameObject> CirculoDict = new Dictionary<GameObject, GameObject>()
    {
        {DERECHA, CIRCULODERECHA },
        {IZQUIERDA, CIRCULOIZQUIERDA },
        {FRENTE, CIRCULOFRENTE },
        {IZQUIERDAABAJO, CIRCULOIZQUIERDAABAJO },
        {DERECHAABAJO, CIRCULODERECHAABAJO }
    };
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
    }
    // Update is called once per frame
    void Update()
    {
        //FALTA HACER QUE A MEDIDA QUE PASA EL TIEMPO EL ANILLO ACHIQUE MAS RAPIDO CON UN MAXIMO DE VELOCIDAD
        if (!IsActiveCircle)
        {
            CrearAnillo();
        }
    }
    public void PerdioVida()
    {
        //pierde vida
        Destroy(Circle);
        IsActiveCircle = false;
    }

    void CrearAnillo()
    {
        random = Random.Range(0, PartesCuerpo.Length);
        ParteCuerpo = PartesCuerpo[random];
        Circle = Instantiate(AnilloPreFab, CirculoDict[PartesCuerpo[random]].transform.position, CirculoDict[PartesCuerpo[random]].transform.rotation);
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
            Destroy(Circle);
            IsActiveCircle = false;
        }
    }
}
