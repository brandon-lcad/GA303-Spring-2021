using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct Choice {

    // What text to display on the button
    [TextArea(2, 5)]
    public string text;

    // The next conversation that results from pressing the button
    public Conversation nextConversation;

    // The impact this choice has on the distortion level
    public int distortionEffect;

    public string nextScene;
}

[CreateAssetMenu(fileName = "New Decision", menuName = "Scriptable Objects/Decision")]
public class Decision : ScriptableObject
{
    [TextArea(2, 5)]
    public string text;
    public Choice[] choices;
}
