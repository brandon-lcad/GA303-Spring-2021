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

    public Button nextButton;

    public Image portrait;
    public TMP_Text characterName;

    public GameObject characterBubble;
    public TMP_Text characterDialogue;

    public GameObject playerBubble;
    public TMP_Text playerDialogue;

    public GameObject decUI;

    public Character chara;
    public Conversation convo;

    public QuestionEvent questionEvent;

    public int distortionLevel;
    private int activeLineIndex = 0;

    private bool conversationStarted = false;
    private bool makingDecision = false;

    // Start is called before the first frame update
    void Awake()
    {
        playerBubble.SetActive(false);
        playerDialogue.text = "";
        characterBubble.SetActive(false);
        characterDialogue.text = "";
        decUI.SetActive(false);

        ui.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (!makingDecision){
        if (Input.GetKeyDown("space"))
        {
          AdvanceConversation();
        }
      }
    }

    // This function progresses the conversation upon click or space bar; made public so a button can be implemented
    public void AdvanceConversation()
    {
        // // If there's a question, show question
        // if (convo.decision != null){
        //   questionEvent.Invoke(convo.decision);
        // }
        //
        // // If there's a next conversation, start next conversation
        // else if (convo.nextConvo != null){
        //   ChangeConversation(convo.nextConvo);
        // }
        //
        // // If there's neither a question or conversation, end conversation
        // else{
        //   EndConversation();
        // }

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
            // No more lines to read; is a question present?
            // if so, present it to the player
            if (convo.decision != null){
              // ui.enabled = false;
              // Turn on Decision UI
              decUI.SetActive(true);
              // Turn off Character UIs
              playerBubble.SetActive(false);
              characterBubble.SetActive(false);
              portrait.enabled = false;
              disableNextInput();

              decUI.SendMessage("Change", convo.decision);
            }
            // hide the speaker UI
            //ui.enabled = false;
        }
    }

    void disableNextInput(){
      nextButton.gameObject.SetActive(false);
      makingDecision = true;
    }

    void enableNextInput(){
      nextButton.gameObject.SetActive(true);
      makingDecision = false;
    }

    // Updates text and bubbles to correspond to current line in convo and advances activeLineIndex to next line
    void DisplayLine()
    {
        Line line = convo.lines[activeLineIndex];
        Character character = line.character;
        portrait.enabled = true;

        if (character.isPlayer)
        {
            playerBubble.SetActive(true);
            characterBubble.SetActive(false);
            playerDialogue.text = line.text.ToString();
        }
        else if (!character.isPlayer)
        {
            playerBubble.SetActive(false);
            characterBubble.SetActive(true);
            characterDialogue.text = line.text.ToString();
            portrait.sprite = line.character.characterSprites[distortionLevel];
        }
        else
        {
            playerBubble.SetActive(false);
            characterBubble.SetActive(false);
        }

        // characterName.text = line.character.characterName;
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

    void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
    }

    // Listens for ConversationChangeEvent and changes Conversation accordingly
    public void ChangeConversation(Conversation nextConvo)
    {
        convo = nextConvo;
        activeLineIndex = 0;
        decUI.SetActive(false);
        enableNextInput();
        AdvanceConversation();
    }

    //
    void EndConversation()
    {
        convo = null;
        conversationStarted = false;
    }

    //private void SetDialogue(
    //    SpeakerUI activeSpeakerUI,
    //    SpeakerUI inactiveSpeakerUI,
    //    string text)
    //{
    //    activeSpeakerUI.Dialogue = text;
    //    activeSpeakerUI.Show();
    //    inactiveSpeakerUI.Hide();
    //}

}
