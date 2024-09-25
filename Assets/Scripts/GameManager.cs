using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool golpeRecibido = false;
    public static GameManager Instance;
    public List<GameObject> list = new List<GameObject>();
    public bool IsFinished = false;
    public bool IsFinished2 = false;
    public bool stuned = false;
    public bool dead = false;
    public bool IsCheating = false;
    public float HpLocal;
    public bool IsInvulnerable = false;
    public GameObject[] Normales;
    public GameObject[] Variantes;
    bool normal = true;


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        GuantesNormal(true);
        Normales = GameObject.FindGameObjectsWithTag("Normales");
        Variantes = GameObject.FindGameObjectsWithTag("Variantes");
    }

    public void ChangeScene(string sceneName)
    {
        Normales = GameObject.FindGameObjectsWithTag("Normales");
        Variantes = GameObject.FindGameObjectsWithTag("Variantes");
        SceneManager.LoadScene(sceneName);
        if (normal)
        {
            GuantesNormal(true);
        }
        else
        {
            GuantesNormal(false);
        }
    }

    public bool HaRecibidoGolpe()
    {
        if (golpeRecibido)
        {
            if (IsFinished == true)
            {
                golpeRecibido = false;  // Resetear el estado después de detectar el golpe
            }
            return true;
        }
        return false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            IsCheating = !IsCheating;

            if (IsCheating)
            {
                Debug.Log("Cheating activado");
            }
            else
            {
                Debug.Log("Cheating desactivado");
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            IsInvulnerable = !IsInvulnerable;
        }
    }

    public void GuantesNormal(bool GuantesNormal)
    {
        if (GuantesNormal)
        {
            normal = true;
            foreach (GameObject guante in Normales)
            {
                guante.SetActive(true);
            }
            foreach (GameObject guante in Variantes)
            {
                guante.SetActive(false);
            }
        }
        else if (!GuantesNormal)
        {
            normal = false;
            foreach (GameObject guante in Normales)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Variantes)
            {
                guante.SetActive(true);
            }
        }
    }
}




