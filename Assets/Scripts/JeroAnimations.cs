using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeroAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
