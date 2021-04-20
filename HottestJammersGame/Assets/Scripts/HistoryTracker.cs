using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistoryTracker : MonoBehaviour
{
    public DialogueManager dialogueScript;

    public Canvas canvas;
    public TMP_Text historyText;

    public bool convoStarted;
    public bool canvasOn;

    void Awake()
    {
        historyText.text = " ";
    }

    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            TurnCanvasOnOff();
        }
    }

    // activeLineIndex needs to be public for this to work
    public void HistoryWriter()
    {
        Line line = dialogueScript.convo.lines[dialogueScript.activeLineIndex];

        if (!convoStarted)
        {
            historyText.text = line.character.characterName.ToString() + ": " + line.text.ToString();
            convoStarted = true;
        }
        else
        {
            historyText.text += "\n" + line.character.characterName.ToString() + ": " + line.text.ToString();
        }
    }

    void TurnCanvasOnOff()
    {
        canvasOn = !canvasOn;
        if (canvasOn)
        {
            canvas.enabled = false;
        }
        else
        {
            canvas.enabled = true;
        }
    }
}
