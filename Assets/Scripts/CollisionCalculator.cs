using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;
using Unity.VisualScripting;

public class CollisionCalculator : MonoBehaviour
{
    // El Collider del otro objeto con el que el Plane está colisionando
    Collider otherObjectCollider;
    public HealthBarScript healthbar;
    float daño = 2f;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Exit HitBox" && other.gameObject.tag == "Enemigo")
        {
            healthbar.hp -= daño;
        }
    }
}
