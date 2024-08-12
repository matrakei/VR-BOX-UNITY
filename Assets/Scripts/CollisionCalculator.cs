using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionCalculator : MonoBehaviour
{
    // El Collider del otro objeto con el que el Plane está colisionando
    public Collider otherObjectCollider;
    float intersectionPercentagemax;
    public TMP_Text DAÑO;
    public HealthBarScript healthbar;
    int daño;
    int dañomax = 10;
    // Método llamado cuando comienza la colisión

    private void OnTriggerStay(Collider other)
    {
        if (other == otherObjectCollider)
        {
            CalculateIntersectionPercentage();
        }
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
            DAÑO.text = "Daño: " + intersectionPercentagemax;

            daño = CalculateDamage((int)intersectionPercentagemax);
            healthbar.hp -= daño;
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

    private int CalculateDamage(int intersectionPercentage)
    {
        if (intersectionPercentage >= 100)
        {
            return 10; // Daño máximo
        }
        else if (intersectionPercentage >= 50)
        {
            // Proporcionalidad entre 1 y 10 en el rango de 50% a 100%
            return 1 + 9 * ((intersectionPercentage - 50) / 50);
        }
        else
        {
            return 1; // Daño mínimo
        }
    }
}
