using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "New Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    // The name of the character on screen
    public string characterName;
    // The sprites available for the distortion manager to select from (TURN INTO AN ARRAY!!)
    public Sprite[] characterSprites;
}
