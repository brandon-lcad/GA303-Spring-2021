using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalChoiceRecorder : MonoBehaviour
{
    public static GlobalChoiceRecorder GCRInstance;

    public int globalDistortionLevel;

    void Awake()
    {
        if (GCRInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            GCRInstance = this;
        }
        else if (GCRInstance != this)
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
      if (scene.name == "02_Home")
      {
        globalDistortionLevel = 0;
      }
    }
}
