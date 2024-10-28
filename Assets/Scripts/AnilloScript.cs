using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnilloScript : MonoBehaviour
{
    public DesafioScript desafioScript;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0.01f)
        {
            transform.localScale -= Vector3.one * speed * Time.deltaTime;
        }
        else
        {
            Debug.Log("Perdiste 1");
            desafioScript.PerdioVida();
        }
    }
}
