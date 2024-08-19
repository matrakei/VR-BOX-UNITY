using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CollisionManager : MonoBehaviour
{

    public GameObject PERSONAJE;
    public TMP_Text debug;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLISION");
        Vector3 objectCenter = transform.position;
        Vector3 collisionPoint = collision.contacts[0].point;
        Debug.DrawLine(objectCenter, collisionPoint, Color.red, 2.0f);
        debug.text = "CENTRO:"+objectCenter+"\r\nCOLISION:"+collisionPoint;
        Debug.Log("CENTRO:"+objectCenter+"\r\nCOLISION:"+collisionPoint);
        DetectarLado(objectCenter, collisionPoint);
    }

    private void DetectarLado(Vector3 CENTRO, Vector3 CONTACTO)
    {
        
        if (CENTRO.x > CONTACTO.x)
        {

        }
        else
        {
            
        }
    }
}