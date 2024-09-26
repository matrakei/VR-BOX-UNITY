using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
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

    void OnEnable()
    {
        // Suscribirse al evento de cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        // Desuscribirse del evento de cambio de escena
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Normales = GameObject.FindGameObjectsWithTag("Normales");
        Variantes = GameObject.FindGameObjectsWithTag("Variantes");
        if (normal)
        {
            GuantesNormal(true);
        }
        else
        {
            GuantesNormal(false);
        }
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
    void Update()
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
            if (IsInvulnerable)
            {
                Debug.Log("Invulnerable activado");
            }
            else
            {
                Debug.Log("Invulnerable desactivado");
            }
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
    IEnumerator Stuneado(float seconds)
    {
        GameManager.Instance.stuned = true;
        yield return new WaitForSeconds(seconds);
        GameManager.Instance.stuned = false;
    }
    public void Stun(float seconds)
    {
        StartCoroutine(Stuneado(seconds));
    }
}




