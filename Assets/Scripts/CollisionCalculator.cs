using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System;

public class CollisionCalculator : MonoBehaviour
{
    // El Collider del otro objeto con el que el Plane está colisionando
    Collider otherObjectCollider;
    float intersectionPercentagemax;
    public TMP_Text PORCENTAJE;
    public HealthBarScript healthbar;
    public TMP_Text DAÑO;
    float daño;
    

    // Método llamado cuando comienza la colisión

    private void OnTriggerStay(Collider other)
    {
        otherObjectCollider = other;
        
            CalculateIntersectionPercentage();
        
    }

    // Método para calcular el porcentaje de intersección
    private void CalculateIntersectionPercentage()
    {
        // Obtén los límites (Bounds) del Plane y del otro objeto
        Bounds planeBounds = GetComponent<Collider>().bounds;
        Bounds otherBounds = otherObjectCollider.bounds;

        // Comprueba si hay intersección
        if (planeBounds.Intersects(otherBounds))
        {
            // Calcula la intersección de los límites
            Bounds intersectionBounds = CalculateIntersectionBounds(planeBounds, otherBounds);

            // Calcula el área del Plane
            float planeArea = planeBounds.size.x * planeBounds.size.z;

            // Calcula el área de la intersección
            float intersectionArea = intersectionBounds.size.x * intersectionBounds.size.z;

            // Calcula el porcentaje de intersección
            float intersectionPercentage = (intersectionArea / planeArea) * 100f;

            // Muestra el resultado en la consola
            if (intersectionPercentage > intersectionPercentagemax)
            {
                intersectionPercentagemax = intersectionPercentage;
            }
        }
        else
        {
            Debug.Log("No hay intersección entre el Plane y el otro objeto.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == otherObjectCollider)
        {
            Debug.Log("El porcentaje de intersección máximo es: " + intersectionPercentagemax + "%");
            PORCENTAJE.text = "%%%: " + intersectionPercentagemax + "%";


            daño = CalculateDamage(Convert.ToInt32(intersectionPercentagemax));
            healthbar.hp -= daño;
            DAÑO.text = "Daño: " + daño;
            intersectionPercentagemax = 0;
        }
    }

    // Método para calcular los límites de la intersección
    private Bounds CalculateIntersectionBounds(Bounds planeBounds, Bounds otherBounds)
    {
        Vector3 minPoint = Vector3.Max(planeBounds.min, otherBounds.min);
        Vector3 maxPoint = Vector3.Min(planeBounds.max, otherBounds.max);
        return new Bounds((minPoint + maxPoint) / 2, maxPoint - minPoint);
    }

    private float CalculateDamage(int intersectionPercentage)
    {
        if (intersectionPercentage >= 100f)
        {
            return 10f; // Daño máximo
        }
        else if (intersectionPercentage >= 50f)
        {
            // Proporcionalidad entre 1 y 10 en el rango de 50% a 100%
            return 1f + 9f * ((intersectionPercentage - 50f) / 50f);
        }
        else
        {
            return 1f; // Daño mínimo
        }
    }
}
