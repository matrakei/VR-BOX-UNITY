using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioCollisionScript : MonoBehaviour
{
    DesafioScript desafioScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //falta mejorar la comptibilidad con la escena, osea que no se bugueo con funcionalidades no usadas
        desafioScript.DetectoColision(gameObject);
    }
}
