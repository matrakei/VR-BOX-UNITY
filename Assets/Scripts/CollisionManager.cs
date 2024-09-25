using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CollisionManager : MonoBehaviour
{
    JeroAnimations jeroAnimations;
    GameObject DERECHA;
    GameObject IZQUIERDA;
    GameObject FRENTE;
    GameObject IZQUIERDAABAJO;
    GameObject DERECHAABAJO;
    HealthBarScript healthbar;
    public GameObject sweatParticlesPrefab;  // Prefab de las partículas de sudor
    public float particleLifetime = 1.0f;


    private void Awake()
    {
        DERECHA = GameObject.Find("DERECHA");
        IZQUIERDA = GameObject.Find("IZQUIERDA");
        FRENTE = GameObject.Find("FRENTE");
        IZQUIERDAABAJO = GameObject.Find("IZQUIERDA ABAJO");
        DERECHAABAJO = GameObject.Find("DERECHA ABAJO");
        jeroAnimations = GameObject.Find("Jero").GetComponent<JeroAnimations>();
        healthbar = GameObject.Find("HealthBar").GetComponent<HealthBarScript>();
        if (healthbar == null)
        {
            Debug.LogError("HealthBarScript no encontrado");
        }
    }
    private void DeactivateAll()
    {
        IZQUIERDA.layer = 6;
        DERECHA.layer = 6;
        FRENTE.layer = 6;
        DERECHAABAJO.layer = 6;
        IZQUIERDAABAJO.layer = 6;
        Debug.Log("DESACTIVADOS");
    }

    private void Update()
    {
        if (GameManager.Instance.stuned == true)
        {
            FRENTE.layer = 6;
            DERECHA.layer = 6;
            IZQUIERDA.layer = 6;
        }
        if (GameManager.Instance.list.Count > 0)
        {
            DeactivateAll();
            if (GameManager.Instance.list[0] == DERECHA)
            {
                GameManager.Instance.list.Clear();
                jeroAnimations.anim.SetTrigger("IsRightHeadHit");
                healthbar.hp -= 10;
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
            SoundManager.Instance.BasicPunchSFX();
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (gameObject.name != "Exit HitBox")
        {
            if (GameManager.Instance.IsCheating)
            {
                healthbar.hp = -1;
            }
            if (GameManager.Instance.IsInvulnerable)
            {
                GameManager.Instance.HpLocal = healthbar.hp;
                healthbar.hp = 100000;
                healthbar.maxhp = 100000;
            }
            else if (!GameManager.Instance.IsInvulnerable)
            {
                healthbar.hp = GameManager.Instance.HpLocal;
                healthbar.maxhp = Convert.ToInt32(GameManager.Instance.HpLocal);
            }

            if (GameManager.Instance.stuned == false)
            {
                FRENTE.layer = 8;
                DERECHA.layer = 8;
                IZQUIERDA.layer = 8;
            }
            if (other.gameObject.tag == "Guante")
            {
                Debug.Log(gameObject.name);
                Debug.Log(gameObject.layer);
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
                // Obtener el punto de contacto aproximado usando la posición del otro objeto (puño)
                Vector3 contactPoint = other.ClosestPoint(transform.position);

                // Obtener la dirección del golpe (desde el puño hacia el punto de contacto)
                Vector3 hitDirection = (contactPoint - other.transform.position).normalized;

                // Instanciar las partículas en el punto de contacto
                GameObject particles = Instantiate(sweatParticlesPrefab, contactPoint, Quaternion.LookRotation(hitDirection));

                // Destruir las partículas después de un tiempo
                Destroy(particles, particleLifetime);
                Debug.Log("Particle generada");
            }
        }
        void OnTriggerExit()
        {
            if (gameObject.name == "Exit HitBox")
            {
                ActivateAll();
            }
        }

        void ActivateAll()
        {
            IZQUIERDA.layer = 8;
            DERECHA.layer = 8;
            FRENTE.layer = 8;
            DERECHAABAJO.layer = 8;
            IZQUIERDAABAJO.layer = 8;
            Debug.Log("ACTIVADOS");

        }
    }

}
