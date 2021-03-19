using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct Choice {

    [TextArea(2, 5)]
    public string text;

    public Conversation nextConversation;

    public int distortionEffect;
}

[CreateAssetMenu(fileName = "New Decision", menuName = "Scriptable Objects/Decision")]
public class Decision : ScriptableObject
{
    [TextArea(2, 5)]
    public string text;
    public Choice[] choices;
}
