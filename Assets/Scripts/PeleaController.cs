
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

public class PeleaController : MonoBehaviour
{
    public Animator animator;    
    // Falta comunicarse on el CollisionManager para saber si Jero ha recibido un golpe
    public float tiempoEspera = 5.0f;
    int UltimoAtaque;


    private string[] ataques = { "GolpeFrente", "GolpeTorsoIzquierdo", "GolpeTorsoDerecho", "GolpeIzquierdo" };
    //FALTA ATAQUE GOLPE FRENTE 2 (DE DERECHA O IZQUIERDA)
    //FALTA ATAQUE GOLPE DERECHA
    private string[] defensas = { "CubrirIzquierda", "CubrirDerecha", "CubrirFrente", "CubrirTorsoIzquierdo", "CubrirTorsoDerecho" };

    private bool esperandoRespuesta = false;

    void Start()
    {
        StartCoroutine(RealizarAcciones());
    }

    IEnumerator RealizarAcciones()
    {
        while (true)
        {
            if (!esperandoRespuesta)
            {
                Atacar();
                esperandoRespuesta = true;
            }
            else
            {
                
                // Verificar si Jero ha recibido un golpe
                if (GameManager.Instance.HaRecibidoGolpe() == true)
                {
                    if (GameManager.Instance.IsFinished == true)
                    {
                        esperandoRespuesta = false;
                        GameManager.Instance.IsFinished = false;
                    }
                }
                else
                {
                    if (GameManager.Instance.IsFinished2 == true)
                    {
                        yield return new WaitForSeconds(tiempoEspera);
                        esperandoRespuesta = false;
                        GameManager.Instance.IsFinished2 = false;
                    }
                }
            }
            yield return null;
        }
    }
    void Atacar()
    {
        int indiceAtaque = Random.Range(0, ataques.Length);
        while (indiceAtaque == UltimoAtaque)
        {
            indiceAtaque = Random.Range(0, ataques.Length);
        }
        animator.SetTrigger(ataques[indiceAtaque]);
        
        UltimoAtaque = indiceAtaque;
    }

    void IsAttacking()
    {

    }
}