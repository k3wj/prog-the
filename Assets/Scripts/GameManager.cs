using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isPaused;
    public bool hasStarted;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);

            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    { 
        throw new KeyNotFoundException();
    }

    public void GameOver()
    { 
        throw new KeyNotFoundException();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            ExitGame();
        }
    }
}
