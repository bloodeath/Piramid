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
        lastLevelLoaded = SceneManager.GetActiveScene().name;
    }

    public void loadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        lastLevelLoaded = levelName;
    }

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
