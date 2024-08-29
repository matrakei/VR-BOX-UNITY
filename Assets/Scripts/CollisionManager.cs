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
    public HealthBarScript healthbar;


    private void DeactivateAll()
    {
        IZQUIERDA.layer = 6;
        DERECHA.layer = 6;
        FRENTE.layer = 6;
        DERECHAABAJO.layer = 6;
        IZQUIERDAABAJO.layer = 6;
        BRAZODERECHO.layer = 6;
        BRAZOIZQUIERDO.layer = 6;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "DERECHA")
        {
            //Golpe de derecha
            DeactivateAll();
            healthbar.hp -= 10;
            jeroAnimations.anim.SetBool("IsRightHeadHit", true);

        }
        else if (gameObject.name == "IZQUIERDA")
        {
            //Golpe de izquierda
            DeactivateAll();
            healthbar.hp -= 10;
            jeroAnimations.anim.SetBool("IsLeftHeadHit", true);
        }
        else if (gameObject.name == "FRENTE")
        {
            //Golpe de frente
            DeactivateAll();
            healthbar.hp -= 7;
            jeroAnimations.anim.SetBool("IsFrontHeadHit", true);
        }
        else if (gameObject.name == "IZQUIERDA ABAJO")
        {
            //Golpe de izquierda abajo
            DeactivateAll();
            healthbar.hp -= 15;
            //falta la animacion
            //jeroAnimations.anim.SetBool("IsTorsoLeftHit", true);
        }
        else if (gameObject.name == "DERECHA ABAJO")
        {
            //Golpe de derecha abajo
            DeactivateAll();
            healthbar.hp -= 15;
            jeroAnimations.anim.SetBool("IsTorsoRightHit", true);
        }
        else if (gameObject.name == "BRAZO DERECHO")
        {
            //Golpe de brazo derecho
            DeactivateAll();
            healthbar.hp -= 2;
            //posible animacion
        }
        else if (gameObject.name == "BRAZO IZQUIERDO")
        {
            //Golpe de brazo izquierdo
            DeactivateAll();
            healthbar.hp -= 2;
            //posible animacion
        }
    }

    private void OnTriggerExit()
    {
        if (gameObject.name == "Exit HitBox")
        {
            IZQUIERDA.layer = 8;
            DERECHA.layer = 8;
            FRENTE.layer = 8;
            DERECHAABAJO.layer = 8;
            IZQUIERDAABAJO.layer = 8;
            BRAZODERECHO.layer = 8;
            BRAZOIZQUIERDO.layer = 8;

            //lo de abajo no se si esta bien onda  la forma de terminar la animacion
            jeroAnimations.anim.SetBool("IsRightHeadHit", false);
            jeroAnimations.anim.SetBool("IsLeftHeadHit", false);
            jeroAnimations.anim.SetBool("IsFrontHeadHit", false);
            jeroAnimations.anim.SetBool("IsTorsoRightHit", false);
            //falta la animacion
            //jeroAnimations.anim.SetBool("IsTorsoLeftHit", false);
        }
    }
}