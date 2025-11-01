using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }

    }

    public void LoadLevel(string sceneName) // hook up with a button
    {
        if (sceneName == "MainMenu")
        {
            DestroyAllPersistentObjects();

        }
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void DestroyAllPersistentObjects()
    {
        Scene dontDestroyScene = SceneManager.GetSceneByName("DontDestroyOnLoad");

        if (!dontDestroyScene.IsValid())
        {
            Debug.Log("No DontDestroyOnLoad scene found.");
            return;
        }

        GameObject[] rootObjects = dontDestroyScene.GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
            Destroy(obj);
        }
    
    }

}
