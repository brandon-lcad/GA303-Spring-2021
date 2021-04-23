using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour
{
    public Conversation startingConversation;
    public static Resetter ResetterInstance;

    void Awake()
    {
        if (ResetterInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            ResetterInstance = this;
        }
        else if (ResetterInstance != this)
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      if (scene.name == "Introduction")
      {
        GameObject dm = GameObject.Find("DialogueManager");
        dm.SendMessage("ChangeConversation", startingConversation);
      }
    }
}
