using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum CharacterEffects{
  Meet
}

[System.Serializable]
public struct Choice {

    // What text to display on the button
    [TextArea(2, 5)]
    public string text;

    // The next conversation that results from pressing the button
    public Conversation nextConversation;

    // The impact this choice has on the distortion level
    public int distortionEffect;

    // Brute forcing to get through Hot Jam, REMOVE THESE IN ACTUAL BUILD
    public string nextScene;

    // Character effect bool
    public bool hasEffect;

    // Character impacted
    public Character character;

    // Character effect
    public CharacterEffects impact;
}

[CreateAssetMenu(fileName = "New Decision", menuName = "Scriptable Objects/Decision")]
public class Decision : ScriptableObject
{
    [TextArea(2, 5)]
    public string text;
    public Choice[] choices;
}
