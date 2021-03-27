using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalChoiceRecorder : MonoBehaviour
{
    public static GlobalChoiceRecorder Instance;

    public int globalDistortionLevel;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }

    // Set globaDistortionLevel to 0
    void Start()
    {
      SceneManager.sceneLoaded += OnSceneLoaded;
      globalDistortionLevel = 0;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      if (scene.name == "Introduction")
      {
        globalDistortionLevel = 0;
      }
    }
}
