using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public HealthBarScript healthbar;
    public GameObject DERECHA;
    public GameObject IZQUIERDA;
    public GameObject FRENTE;
    public GameObject IZQUIERDAABAJO;
    public GameObject DERECHAABAJO;
    //public GameObject BRAZODERECHO;
    //public GameObject BRAZOIZQUIERDO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision");

        if (gameObject.name == "DERECHA")
        {
            //Golpe de derecha
            IZQUIERDA.layer = 6;
            DERECHA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            //BRAZODERECHO.layer = 6;
            //BRAZOIZQUIERDO.layer = 6;
            healthbar.hp -= 10;
        }
        else if (gameObject.name == "IZQUIERDA")
        {
            //Golpe de izquierda
            IZQUIERDA.layer = 6;
            DERECHA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            //BRAZODERECHO.layer = 6;
            //BRAZOIZQUIERDO.layer = 6;
            healthbar.hp -= 10;   
        }
        else if (gameObject.name == "FRENTE")
        {
            //Golpe de frente
            IZQUIERDA.layer = 6;
            DERECHA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            //BRAZODERECHO.layer = 6;
            //BRAZOIZQUIERDO.layer = 6;
            healthbar.hp -= 7;
        }
        else if (gameObject.name == "IZQUIERDA ABAJO")
        {
            //Golpe de izquierda abajo
            IZQUIERDA.layer = 6;
            DERECHA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            //BRAZODERECHO.layer = 6;
            //BRAZOIZQUIERDO.layer = 6;
            healthbar.hp -= 15;
        }
        else if (gameObject.name == "DERECHA ABAJO")
        {
            //Golpe de derecha abajo
            IZQUIERDA.layer = 6;
            DERECHA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            //BRAZODERECHO.layer = 6;
            //BRAZOIZQUIERDO.layer = 6;
            healthbar.hp -= 15;
        }
        else if (gameObject.name == "BRAZO DERECHO")
        {
            //Golpe de brazo derecho
            IZQUIERDA.layer = 6;
            DERECHA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            //BRAZODERECHO.layer = 6;
            //BRAZOIZQUIERDO.layer = 6;
            healthbar.hp -= 2;
        }
        else if (gameObject.name == "BRAZO IZQUIERDO")
        {
            //Golpe de brazo izquierdo
            IZQUIERDA.layer = 6;
            DERECHA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            //BRAZODERECHO.layer = 6;
            //BRAZOIZQUIERDO.layer = 6;
            healthbar.hp -= 2;
        }
    }
    private void OnTriggerExit()
    {
        if (gameObject.name == "Exit Player HitBox")
        {
            IZQUIERDA.layer = 9;
            DERECHA.layer = 9;
            FRENTE.layer = 9;
            DERECHAABAJO.layer = 9;
            IZQUIERDAABAJO.layer = 9;
            //BRAZODERECHO.layer = 9;
            //BRAZOIZQUIERDO.layer = 9;
        }
    }
}
