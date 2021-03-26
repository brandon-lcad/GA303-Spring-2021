using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalChoiceRecorder : MonoBehaviour
{
    public static GlobalChoiceRecorder Instance;

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

}
