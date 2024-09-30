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
    GameObject DERECHA;
    GameObject IZQUIERDA;
    GameObject FRENTE;
    GameObject IZQUIERDAABAJO;
    GameObject DERECHAABAJO;
    GameObject playButton;
    GameObject GuantesButton;
    string lastScene;
    string nowScene;


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
        playButton = GameObject.Find("Boton Jugar");
        GuantesButton = GameObject.Find("Guantes Button");
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
        DERECHA = GameObject.Find("DERECHA");
        IZQUIERDA = GameObject.Find("IZQUIERDA");
        FRENTE = GameObject.Find("FRENTE");
        IZQUIERDAABAJO = GameObject.Find("IZQUIERDA ABAJO");
        DERECHAABAJO = GameObject.Find("DERECHA ABAJO");
        IsFinished = false;
        list.Clear();
        if (IZQUIERDA != null && DERECHA != null && FRENTE != null && IZQUIERDAABAJO != null && DERECHAABAJO != null)
        {
            IZQUIERDA.layer = 8;
            DERECHA.layer = 8;
            FRENTE.layer = 8;
            DERECHAABAJO.layer = 8;
            IZQUIERDAABAJO.layer = 8;
        }
        if (lastScene == "Level" && SceneManager.GetActiveScene().name == "Menu Past Inicio")
        {
            playButton.layer = 6;
            GuantesButton.layer = 6;
        }
        
    }
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(SceneChanger(sceneName));
    }
    //IEnumerator WaitToColide(float seconds)
    //{
    //    GuantesButton.layer = 6;
    //    playButton.layer = 6;
    //    yield return new WaitForSeconds(seconds);
    //    GuantesButton.layer = 0;
    //    playButton.layer = 0;
    //}

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
    IEnumerator SceneChanger(string sceneName)
    {
        Debug.Log("Funcionando");
        lastScene = SceneManager.GetActiveScene().name;
        Debug.Log("lastScene: " + lastScene);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Debug.Log("Escena cargada");
        nowScene = SceneManager.GetActiveScene().name;
        Debug.Log("nowScene: " + nowScene);
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




