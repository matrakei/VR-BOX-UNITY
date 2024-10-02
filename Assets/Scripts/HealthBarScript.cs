using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthbar;
    public Canvas bar;
    public int maxhp = 1000;
    public float hp;
    public TMP_Text texthp;
    public GameObject personaje;
    public GameObject PlayAgainButton;
    public GameObject Congrats;
    public GameObject BotonSalir;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
        healthbar.value = maxhp;
        healthbar.maxValue = maxhp;
        texthp.text = maxhp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthbar.value != hp)
        {
            if (hp <= 0)
            {
                healthbar.value = 0;
                texthp.text = "0";
                GameManager.Instance.dead = true;
                bar.enabled = false;
                StartCoroutine(Kill());

            }
            else
            {
                healthbar.value = hp;
                texthp.text = hp.ToString();
            }
        }
    }
    IEnumerator Kill()
    {
        anim.SetTrigger("IsDead");
        yield return new WaitForSeconds(5);
        personaje.SetActive(false);
        Congrats.SetActive(true);
    }
}
