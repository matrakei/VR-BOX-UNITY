using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthbar;
    public GameObject bar;
    public int maxhp = 100;
    public float hp;
    public TMP_Text texthp;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
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
                bar.SetActive(false);
            }
            else
            {
                healthbar.value = hp;
                texthp.text = hp.ToString();
            }
        }
    }
}
