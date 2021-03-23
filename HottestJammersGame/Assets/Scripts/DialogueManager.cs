using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class QuestionEvent : UnityEvent<Decision> { }

public class DialogueManager : MonoBehaviour
{
    public Canvas ui;

    public Image portrait;
    // public TMP_Text characterName;

    public Image characterBubble;
    public TMP_Text characterDialogue;

    public Image playerBubble;
    public TMP_Text playerDialogue;

    public Character chara;
    public Conversation convo;

    public QuestionEvent questionEvent;

    public int distortionLevel;
    private int activeLineIndex = 0;

    private bool conversationStarted = false;

    public 

    // Start is called before the first frame update
    void Awake()
    {
        ui.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
    }

    void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
    }

    public void AdvanceLine()
    {
        // if there is no conversation, do nothing
        if (convo == null) return;

        // If the conversation has not started, start the conversation
        if (!conversationStarted) Initialize();


        // If there are more lines to read, read next line
        if (activeLineIndex < convo.lines.Length)
            DisplayLine();

        // If there aren't more lines to read, check for next conversation
        else AdvanceConversation();
    }

    // This function progresses the conversation upon click or space bar; made public so a button can be implemented
    public void AdvanceConversation()
    {
        // If there's a question, show question
        if (convo.decision != null)
            questionEvent.Invoke(convo.decision);

        // If there's a next conversation, start next conversation
        else if (convo.nextConvo != null)
            ChangeConversation(convo.nextConvo);

        // If there's neither a question or conversation, end conversation
        else
            EndConversation();

        // If there are more lines to read...
        if (activeLineIndex < convo.lines.Length)
        {
            // set the conversation to started...
            conversationStarted = true;
            // and read the next line
            DisplayLine();
            activeLineIndex += 1;

            // show the speaker UI
            ui.enabled = true;
        }

        else
        {
            // hide the speaker UI
            ui.enabled = false;
        }
    }

    void DisplayLine()
    {
        Line line = convo.lines[activeLineIndex];
        Character character = line.character;

        if (character.isPlayer)
        {
            characterBubble.enabled = false;
            characterDialogue.enabled = false;
            playerBubble.enabled = true;
            playerDialogue.enabled = true;
            playerDialogue.text = line.text.ToString();
        }
        else if (!character.isPlayer)
        {
            characterBubble.enabled = true;
            characterDialogue.enabled = true;
            playerBubble.enabled = false;
            playerDialogue.enabled = false;
            characterDialogue.text = line.text.ToString();
            portrait.sprite = line.character.characterSprites[distortionLevel];
        }

        // characterName.text = line.character.characterName;
    }

    public void ChangeConversation(Conversation nextConvo)
    {
        conversationStarted = false;
        convo = nextConvo;
        AdvanceConversation();
    }

    void EndConversation()
    {
        convo = null;
        conversationStarted = false;
    }

}
