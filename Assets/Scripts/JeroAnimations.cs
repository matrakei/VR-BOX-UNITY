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
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("IsMediumHeadHit", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("IsMediumHeadHit", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("IsRightBlocking", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("IsRightBlocking", false);
        }
    }
}
