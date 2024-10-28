using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

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
    GameObject ParteCuerpo;
    public float maxScaleSpeed = 5f;
    public float scaleSpeed = 1f;
    public float increaseAmount = 0.01f;
    bool IsActiveCircle = false;
    GameObject[] PartesCuerpo;
    int random;
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
        //FALTA HACER QUE A MEDIDA QUE PASA EL TIEMPO EL ANILLO ACHIQUE MAS RAPIDO CON UN MAXIMO DE VELOCIDAD
        if (!IsActiveCircle)
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
        IsActiveCircle = true;
        GameManager.Instance.dead = true;
        Destroy(Jero.gameObject);
        
    }

    void CrearAnillo()
    {
        IsActiveCircle = true;
        random = Random.Range(0, PartesCuerpo.Length);
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
        }
    }
    public void AumentarScaleSpeed()
    {
        if (scaleSpeed < maxScaleSpeed)
        scaleSpeed += increaseAmount;
    }
}
