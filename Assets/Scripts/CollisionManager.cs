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
    public HealthBarScript healthbar;


    private void DeactivateAll()
    {
        IZQUIERDA.layer = 6;
        DERECHA.layer = 6;
        FRENTE.layer = 6;
        DERECHAABAJO.layer = 6;
        IZQUIERDAABAJO.layer = 6;
    }

    private void Update()
    {
        if (GameManager.Instance.list.Count > 0)
        {
            DeactivateAll();
            if (GameManager.Instance.list[0] == DERECHA)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsRightHeadHit");
                healthbar.hp -= 10;;
            }
            else if (GameManager.Instance.list[0] == IZQUIERDA)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsLeftHeadHit");
                healthbar.hp -= 10;
            }
            else if (GameManager.Instance.list[0] == FRENTE)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsFrontHeadHit");
                healthbar.hp -= 7;
            }
            else if (GameManager.Instance.list[0] == DERECHAABAJO)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsTorsoRightHit");
                healthbar.hp -= 15;
            }
            else if (GameManager.Instance.list[0] == IZQUIERDAABAJO)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsTorsoLeftHit");
                healthbar.hp -= 15;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Guante")
        {
            if (gameObject.name == "DERECHA")
            {
                GameManager.Instance.list.Add(DERECHA);
                GameManager.Instance.golpeRecibido = true;
            }
            else if (gameObject.name == "IZQUIERDA")
            {
                GameManager.Instance.list.Add(IZQUIERDA);
                GameManager.Instance.golpeRecibido = true;
            }
            else if (gameObject.name == "FRENTE")
            {
                GameManager.Instance.list.Add(FRENTE);
                GameManager.Instance.golpeRecibido = true;
            }
            else if (gameObject.name == "IZQUIERDA ABAJO")
            {
                GameManager.Instance.list.Add(IZQUIERDAABAJO);
                GameManager.Instance.golpeRecibido = true;
            }
            else if (gameObject.name == "DERECHA ABAJO")
            {
                GameManager.Instance.list.Add(DERECHAABAJO);
                GameManager.Instance.golpeRecibido = true;
            }
        }
    }
    private void OnTriggerExit()
    {
        if (gameObject.name == "Exit HitBox")
        {
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
    }
}