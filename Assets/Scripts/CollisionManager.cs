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

    private void Update()
    {
        if (GameManager.Instance.list.Count > 0)
        {
            DeactivateAll();
            if (GameManager.Instance.list[0] == DERECHA)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsRightHeadHit");
                healthbar.hp -= 10;
                Debug.Log("Golpe de derecha");
            }
            else if (GameManager.Instance.list[0] == IZQUIERDA)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsLeftHeadHit");
                healthbar.hp -= 10;
                Debug.Log("Golpe de izquierda");
            }
            else if (GameManager.Instance.list[0] == FRENTE)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsFrontHeadHit");
                healthbar.hp -= 7;
                Debug.Log("Golpe de frente");
            }
            else if (GameManager.Instance.list[0] == DERECHAABAJO)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsTorsoRightHit");
                healthbar.hp -= 15;
                Debug.Log("Golpe de derecha abajo");
            }
            else if (GameManager.Instance.list[0] == IZQUIERDAABAJO)
            {
                GameManager.Instance.list.Clear();
                //jeroAnimations.anim.SetTrigger("IsTorsoLeftHit");
                healthbar.hp -= 15;
                Debug.Log("Golpe de izquierda abajo");
            }
            else if (GameManager.Instance.list[0] == BRAZODERECHO)
            {
                GameManager.Instance.list.Clear();
                //jeroAnimations.anim.SetTrigger("IsRightArmHit");
                healthbar.hp -= 2;
                Debug.Log("Golpe de brazo derecho");
            }
            else if (GameManager.Instance.list[0] == BRAZOIZQUIERDO)
            {
                GameManager.Instance.list.Clear();
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
        else if (gameObject.name == "BRAZO DERECHO")
        {
            GameManager.Instance.list.Add(BRAZODERECHO);
            GameManager.Instance.golpeRecibido = true;
        }
        else if (gameObject.name == "BRAZO IZQUIERDO")
        {
            GameManager.Instance.list.Add(BRAZOIZQUIERDO);
            GameManager.Instance.golpeRecibido = true;
        }
    }
    public bool HaRecibidoGolpe()
    {
        if (GameManager.Instance.golpeRecibido)
        {
            if (GameManager.Instance.IsFinished == true)
            {
                GameManager.Instance.golpeRecibido = false;  // Resetear el estado después de detectar el golpe
            }
            return true;
        }
        return false;
    }
    private void OnTriggerExit()
    {
        if (gameObject.name == "Exit HitBox")
        {
            Debug.Log("Exit HitBox");
            IZQUIERDA.layer = 8;
            DERECHA.layer = 8;
            FRENTE.layer = 8;
            DERECHAABAJO.layer = 8;
            IZQUIERDAABAJO.layer = 8;
            BRAZODERECHO.layer = 8;
            BRAZOIZQUIERDO.layer = 8;
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