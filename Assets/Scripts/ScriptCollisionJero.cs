using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollisionJero : MonoBehaviour
{
    public GameObject Pared;
    private void OnTriggerEnter(Collider other)
    {
        Pared.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Pared.SetActive(false);
    }
}
