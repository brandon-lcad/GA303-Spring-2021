using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This formats the lines of dialogue in the Unity Editor
[System.Serializable]
public struct ConvoLine
{
    // The character involved in the conversation
    public Character character;
    // This is what the character is saying
    [TextArea(2, 5)]
    public string text;
    // This flags this convo if there is dialogue attached to the shadow character
    public bool shadowDialogue;
    // This is what the shadow of the character is thinking
    [TextArea(2, 5)]
    public string shadowText;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Scriptable Objects/Conversation")]
public class Conversation_V02 : ScriptableObject
{
    public ConvoLine[] lines;

    // This is the decision the conversation will lead to
    public Decision decision;

    // This is the next conversation this conversation will lead to
    public Conversation_V02 nextConvo;
}
