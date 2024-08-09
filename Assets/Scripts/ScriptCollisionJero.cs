using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollisionJero : MonoBehaviour
{
    public GameObject Pared;
    public HealthBarScript healthbar;
    int random;
    public int daño;
    public GameObject jero;

    private void Update()
    {
        if (healthbar.hp <= 0)
        {
            jero.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Pared.SetActive(true);
        random = Random.Range(0, daño);
        healthbar.hp -= random;
        if (healthbar.hp < 0)
        {
            healthbar.hp = 0;
            Pared.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Pared.SetActive(false);
    }
}
