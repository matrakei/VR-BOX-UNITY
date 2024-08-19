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

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DERECHA")
        {
            //Golpe de derecha
            IZQUIERDA.layer = 6;
            FRENTE.layer = 6;
            jeroAnimations.anim.SetBool("IsRigthHeadHit", true);
        }
        else if (other.gameObject.tag == "IZQUIERDA")
        {
            //Golpe de izquierda
            FRENTE.layer = 6;
            DERECHA.layer = 6;
            jeroAnimations.anim.SetBool("IsLeftHeadHit", true);
        }
        else
        {
            //Golpe de frente
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
            jeroAnimations.anim.SetBool("IsFrontHeadHit", true);
        }
    }

    private void OnTriggerExit()
    {
        IZQUIERDA.layer = 0;
        DERECHA.layer = 0;
        FRENTE.layer = 0;
        jeroAnimations.anim.SetBool("IsRigthHeadHit", false);
        jeroAnimations.anim.SetBool("IsLeftHeadHit", false);
        jeroAnimations.anim.SetBool("IsFrontHeadHit", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}