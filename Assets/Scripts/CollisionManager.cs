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
    public GameObject BRAZODERECHO;
    public GameObject BRAZOIZQUIERDO;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "DERECHA")
        {
            //Golpe de derecha
            IZQUIERDA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            BRAZODERECHO.layer = 6;
            BRAZOIZQUIERDO.layer = 6;

            jeroAnimations.anim.SetBool("IsRightHeadHit", true);

        }
        else if (gameObject.name == "IZQUIERDA")
        {
            //Golpe de izquierda
            FRENTE.layer = 6;
            DERECHA.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            BRAZODERECHO.layer = 6;
            BRAZOIZQUIERDO.layer = 6;
            jeroAnimations.anim.SetBool("IsLeftHeadHit", true);
        }
        else if (gameObject.name == "FRENTE")
        {
            //Golpe de frente
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
            DERECHAABAJO.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            BRAZODERECHO.layer = 6;
            BRAZOIZQUIERDO.layer = 6;
            jeroAnimations.anim.SetBool("IsFrontHeadHit", true);
        }
        else if (gameObject.name == "IZQUIERDA ABAJO")
        {
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
            FRENTE.layer = 6;
            DERECHAABAJO.layer = 6;
            BRAZODERECHO.layer = 6;
            BRAZOIZQUIERDO.layer = 6;
            jeroAnimations.anim.SetBool("IsTorsoLeftHit", true);
        }
        else if (gameObject.name == "DERECHA ABAJO")
        {
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
            FRENTE.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            BRAZODERECHO.layer = 6;
            BRAZOIZQUIERDO.layer = 6;
            jeroAnimations.anim.SetBool("IsTorsoRightHit", true);
        }
        else if (gameObject.name == "BRAZO DERECHO")
        {
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
            FRENTE.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            DERECHAABAJO.layer = 6;
            BRAZOIZQUIERDO.layer = 6;
            //posible animacion
            jeroAnimations.anim.SetBool("IsRightHeadHit", true);
        }
        else if (gameObject.name == "BRAZO IZQUIERDO")
        {
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
            FRENTE.layer = 6;
            IZQUIERDAABAJO.layer = 6;
            DERECHAABAJO.layer = 6;
            BRAZODERECHO.layer = 6;
            //posible animacion
            jeroAnimations.anim.SetBool("IsRightHeadHit", true);
        }
    }

    private void OnTriggerExit()
    {
        if (gameObject.name == "Exit HitBox")
        {
                IZQUIERDA.layer = 0;
                DERECHA.layer = 0;
                FRENTE.layer = 0;
                DERECHAABAJO.layer = 0;
                IZQUIERDAABAJO.layer = 0;
                BRAZODERECHO.layer = 0;
                BRAZOIZQUIERDO.layer = 0;

                //lo de abajo no se si esta bien onda  la forma de terminar la animacion
                jeroAnimations.anim.SetBool("IsRightHeadHit", false);
                jeroAnimations.anim.SetBool("IsLeftHeadHit", false);
                jeroAnimations.anim.SetBool("IsFrontHeadHit", false);
                jeroAnimations.anim.SetBool("IsTorsoRightHit", false);
                jeroAnimations.anim.SetBool("IsTorsoLeftHit", false);
        }
    }
}