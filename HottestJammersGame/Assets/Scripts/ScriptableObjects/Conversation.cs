using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This formats the lines of dialogue in the Unity Editor
[System.Serializable]
public struct Line
{
    // The character involved in the conversation (This script assumes we only have one character on the screen at a time
    public Character character;
    // This is what the character is saying
    [TextArea(2, 5)]
    public string text;

}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Scriptable Objects/Conversation")]
public class Conversation : ScriptableObject
{
    public Line[] lines;

    // This is the decision the conversation will lead to
    public Decision decision;
}
