using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthbar;
    public int maxhp = 100;
    public int hp;
    public Text texthp;

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
            healthbar.value = hp;
            texthp.text = hp.ToString();
        }
    }
}
