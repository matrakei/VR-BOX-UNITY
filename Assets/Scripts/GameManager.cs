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
}
