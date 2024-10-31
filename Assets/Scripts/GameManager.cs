using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Loading;
using Unity.VisualScripting;
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
    public GameObject[] Estrellas;
    public GameObject[] Supremes;
    bool normal = true;
    bool variante = false;
    bool estrella = false;
    bool supreme = false;
    GameObject DERECHA;
    GameObject IZQUIERDA;
    GameObject FRENTE;
    GameObject IZQUIERDAABAJO;
    GameObject DERECHAABAJO;
    GameObject playButton;
    GameObject GuantesButton;
    string lastScene;
    string nowScene;
    public GameObject Cinturon;
    bool cintu = false;
    bool Aplausos = false;
    public event Action<bool> OnStunedChanged;
    public float stunedTime = 0.8f;
    //algun vambio
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
        Guantes(1);
        Normales = GameObject.FindGameObjectsWithTag("Normales");
        Variantes = GameObject.FindGameObjectsWithTag("Variantes");
        Estrellas = GameObject.FindGameObjectsWithTag("Estrellas");
        Supremes = GameObject.FindGameObjectsWithTag("Supremes");
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
        cintu = false;
        Aplausos = false;
        Cinturon = GameObject.Find("Cinturon");
        if(Cinturon != null)
        Cinturon.SetActive(false);
        playButton = GameObject.Find("Boton Jugar");
        GuantesButton = GameObject.Find("Guantes Button");
        Normales = GameObject.FindGameObjectsWithTag("Normales");
        Variantes = GameObject.FindGameObjectsWithTag("Variantes");
        Estrellas = GameObject.FindGameObjectsWithTag("Estrellas");
        Supremes = GameObject.FindGameObjectsWithTag("Supremes");
        if (normal)
        {
            Guantes(1);
        }
        else if (variante)
        {
            Guantes(2);
        }
        else if (estrella)
        {
            Guantes(3);
        }
        else if (supreme)
        {
             Guantes(4);
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
            //playButton.layer = 6;
            //GuantesButton.layer = 6;
        }
        if (SoundManager.Instance.Audios.clip != SoundManager.Instance.gameMusic && SceneManager.GetActiveScene().name == "Level")
        {
            SoundManager.Instance.Audios.clip = SoundManager.Instance.gameMusic;
            SoundManager.Instance.Audios.Play();
        }
        else if (SoundManager.Instance.Audios.clip != SoundManager.Instance.menuMusic && SceneManager.GetActiveScene().name == "Menu Inicio")
        {
            SoundManager.Instance.Audios.clip = SoundManager.Instance.menuMusic;
            SoundManager.Instance.SFX.clip = SoundManager.Instance.menucheer;
            SoundManager.Instance.Audios.Play();
            SoundManager.Instance.SFX.Play();
        }
        else if (SoundManager.Instance.Audios.clip != SoundManager.Instance.pastmenuMusic[0] && SoundManager.Instance.Audios.clip != SoundManager.Instance.pastmenuMusic[1] && SceneManager.GetActiveScene().name == "Menu Past Inicio")
        {
            int random = UnityEngine.Random.Range(0, SoundManager.Instance.pastmenuMusic.Length);
            SoundManager.Instance.Audios.clip = SoundManager.Instance.pastmenuMusic[random];
            SoundManager.Instance.Audios.Play();
            SoundManager.Instance.SFX.Stop();
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
        if (golpeRecibido && IsFinished)
        {
            golpeRecibido = false;
            return true;
        }
        else
        {

            return false;
        }
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("Bolsa");
        }
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
        if (dead && !Aplausos)
        {
            SoundManager.Instance.PlayMusic(SoundManager.Instance.Aplausos);
            Aplausos = true;
        }
        if (Cinturon != null)
        {
            if (dead && !cintu)
            {
                StartCoroutine(WaitForActive(5));
                cintu = true;
            }
        }
    }
    IEnumerator SceneChanger(string sceneName)
    {
        IsCheating = false;
        IsInvulnerable = false;
        lastScene = SceneManager.GetActiveScene().name;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        nowScene = SceneManager.GetActiveScene().name;
    }
    public void Guantes(int numeroGuante)
    {
        if (numeroGuante == 1)
        {
            normal = true;
            variante = false;
            estrella = false;
            supreme = false;
            foreach (GameObject guante in Normales)
            {
                guante.SetActive(true);
            }
            foreach (GameObject guante in Variantes)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Estrellas)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Supremes)
            {
                guante.SetActive(false);
            }
        }
        else if (numeroGuante == 2)
        {
            normal = false;
            variante = true;
            estrella = false;
            supreme = false;
            foreach (GameObject guante in Normales)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Variantes)
            {
                guante.SetActive(true);
            }
            foreach (GameObject guante in Estrellas)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Supremes)
            {
                guante.SetActive(false);
            }
        }
        else if (numeroGuante == 3)
        {
            normal = false;
            variante = false;
            estrella = true;
            supreme = false;
            foreach (GameObject guante in Normales)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Variantes)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Estrellas)
            {
                guante.SetActive(true);
            }
            foreach (GameObject guante in Supremes)
            {
                guante.SetActive(false);
            }
        }
        else if (numeroGuante == 4)
        {
            normal = false;
            variante = false;
            estrella = false;
            supreme = true;
            foreach (GameObject guante in Normales)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Variantes)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Estrellas)
            {
                guante.SetActive(false);
            }
            foreach (GameObject guante in Supremes)
            {
                guante.SetActive(true);
            }
        }
    }
    IEnumerator Stuneado(float seconds)
    {
        GameManager.Instance.IsStuned = true;
        yield return new WaitForSeconds(seconds);
        GameManager.Instance.IsStuned = false;
    }
    public void Stun(float seconds)
    {
        StartCoroutine(Stuneado(seconds));
    }
    IEnumerator WaitForActive(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Cinturon.SetActive(true);
    }
    private void Start()
    {

        // Activa los displays si están disponibles
        if (Display.displays.Length > 1)
            Display.displays[1].Activate(); // Activa el segundo display

        if (Display.displays.Length > 2)
            Display.displays[2].Activate(); // Activa el tercer display si hay uno
    }
    public bool IsStuned
    {
        get { return stuned; }
        set
        {
            if (stuned != value)
            {
                stuned = value;
                OnStunedChanged?.Invoke(stuned); // Llamar al evento
            }
        }
    }
}




