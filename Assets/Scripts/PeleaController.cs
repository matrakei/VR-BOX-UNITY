
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

public class PeleaController : MonoBehaviour
{
    public Animator animator;
    public CollisionManager collisionManager;  // Referencia al CollisionManager para detectar colisiones
    public float tiempoEspera = 2.0f;
    int UltimoAtaque;


    private string[] ataques = { "JabIzquierdo", "JabDerecho", "GanchoIzquierdo", "GanchoDerecho", "GolpeBajoIzquierdo", "GolpeBajoDerecho" };
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
                yield return new WaitForSeconds(tiempoEspera);
            }
            else
            {
                // Verificar si Jero ha recibido un golpe
                if (collisionManager.HaRecibidoGolpe())
                {
                    if (GameManager.Instance.IsFinished == true)
                    {
                        esperandoRespuesta = false;
                        GameManager.Instance.IsFinished = false;
                    }
                }
                else
                {
                    esperandoRespuesta = false;
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
}