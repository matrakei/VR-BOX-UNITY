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
    List<GameObject> list = new List<GameObject>();


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

    private void Update()
    {
        if (list.Count > 0)
        {
            DeactivateAll();
            if (list[0] == DERECHA)
            {
                list.Clear();
                jeroAnimations.anim.SetTrigger("IsRightHeadHit");
                healthbar.hp -= 10;
                Debug.Log("Golpe de derecha");
            }
            else if (list[0] == IZQUIERDA)
            {
                list.Clear();
                jeroAnimations.anim.SetTrigger("IsLeftHeadHit");
                healthbar.hp -= 10;
                Debug.Log("Golpe de izquierda");
            }
            else if (list[0] == FRENTE)
            {
                list.Clear();
                jeroAnimations.anim.SetTrigger("IsFrontHeadHit");
                healthbar.hp -= 7;
                Debug.Log("Golpe de frente");
            }
            else if (list[0] == DERECHAABAJO)
            {
                list.Clear();
                jeroAnimations.anim.SetTrigger("IsTorsoRightHit");
                healthbar.hp -= 15;
                Debug.Log("Golpe de derecha abajo");
            }
            else if (list[0] == IZQUIERDAABAJO)
            {
                list.Clear();
                //jeroAnimations.anim.SetTrigger("IsTorsoLeftHit");
                healthbar.hp -= 15;
                Debug.Log("Golpe de izquierda abajo");
            }
            else if (list[0] == BRAZODERECHO)
            {
                list.Clear();
                //jeroAnimations.anim.SetTrigger("IsRightArmHit");
                healthbar.hp -= 2;
                Debug.Log("Golpe de brazo derecho");
            }
            else if (list[0] == BRAZOIZQUIERDO)
            {
                list.Clear();
                //jeroAnimations.anim.SetTrigger("IsLeftArmHit");
                healthbar.hp -= 2;
                Debug.Log("Golpe de brazo izquierdo");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "DERECHA")
        {
            list.Add(DERECHA);
        }
        else if (gameObject.name == "IZQUIERDA")
        {
            list.Add(IZQUIERDA);
        }
        else if (gameObject.name == "FRENTE")
        {
            list.Add(FRENTE);
        }
        else if (gameObject.name == "IZQUIERDA ABAJO")
        {
            list.Add(IZQUIERDAABAJO);
        }
        else if (gameObject.name == "DERECHA ABAJO")
        {
            list.Add(DERECHAABAJO);
        }
        else if (gameObject.name == "BRAZO DERECHO")
        {
            list.Add(BRAZODERECHO);
        }
        else if (gameObject.name == "BRAZO IZQUIERDO")
        {
            list.Add(BRAZOIZQUIERDO);
        }
    }

    private void OnTriggerExit()
    {
        if (gameObject.name == "Exit HitBox")
        {
            Debug.Log("Exit HitBox");
            ActivateAll();
        }
    }

    private void ActivateAll()
    {
        IZQUIERDA.layer = 8;
        DERECHA.layer = 8;
        FRENTE.layer = 8;
        DERECHAABAJO.layer = 8;
        IZQUIERDAABAJO.layer = 8;
        BRAZODERECHO.layer = 8;
        BRAZOIZQUIERDO.layer = 8;
    }
}