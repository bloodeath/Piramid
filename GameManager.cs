using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        transform.parent = null;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion

    
    float time = 0;
    string lastLevelLoaded;

    private void Start()
    {
        //lors de la création de notre manager, on récupére la scène active afin d'évité les erreurs
        lastLevelLoaded = SceneManager.GetActiveScene().name;
    }

    public void loadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        lastLevelLoaded = levelName;
    }

    //si le joueur matiens la touche R pendans 2 sec, le niveau se relancera
    private void Update()
    {
        if (Input.GetKey(KeyCode.R)) {
            time += Time.deltaTime;
            if (time > 2)
            {
                loadLevel(lastLevelLoaded);
                time = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
            time = 0;
            
    }
}
