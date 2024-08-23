using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CollisionManager : MonoBehaviour
{
    public JeroAnimations jeroAnimations;
    public GameObject DERECHA;
    public GameObject IZQUIERDA;
    public GameObject FRENTE;
    public GameObject IZQUIERDAABAJO;
    public GameObject DERECHAABAJO;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "DERECHA")
        {
            //Golpe de derecha
            IZQUIERDA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;

            jeroAnimations.anim.SetBool("IsRightHeadHit", true);
        }
        else if (gameObject.tag == "IZQUIERDA")
        {
            //Golpe de izquierda
            FRENTE.layer = 6;
            DERECHA.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            jeroAnimations.anim.SetBool("IsLeftHeadHit", true);
        }
        else if (gameObject.tag == "FRENTE")
        {
            //Golpe de frente
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            jeroAnimations.anim.SetBool("IsFrontHeadHit", true);
        }
        else if (gameObject.tag == "IZQUIERDA ABAJO")
        {
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            jeroAnimations.anim.SetBool("IsDownLeftHit", true);
        }
        else if (gameObject.tag == "DERECHA ABAJO")
        {
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
            FRENTE.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            jeroAnimations.anim.SetBool("IsDownRightHit", true);
        }
    }

    private void OnTriggerExit()
    {
        IZQUIERDA.layer = 0;
        DERECHA.layer = 0;
        FRENTE.layer = 0;
        DERECHAABAJO.layer = 0;
        IZQUIERDAABAJO.layer = 0;
        jeroAnimations.anim.SetBool("IsRightHeadHit", false);
        jeroAnimations.anim.SetBool("IsLeftHeadHit", false);
        jeroAnimations.anim.SetBool("IsFrontHeadHit", false);
        jeroAnimations.anim.SetBool("IsDownRightHit", false);
        jeroAnimations.anim.SetBool("IsDownLeftHit", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}