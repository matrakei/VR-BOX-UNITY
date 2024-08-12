using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollisionJero : MonoBehaviour
{
    public GameObject Pared;
    public HealthBarScript healthbar;
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
        if (other.gameObject.tag == "GUANTES")
        {
            Pared.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GUANTES")
        {
            if (healthbar.hp < 0)
            {
                healthbar.hp = 0;
                Pared.SetActive(false);
            }
            Pared.SetActive(false);
        }
    }
}
