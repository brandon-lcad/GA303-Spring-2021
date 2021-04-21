using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class QuestionsEvent : UnityEvent<Decision> { }

public class DialogueManager_V02 : MonoBehaviour
{

    public Conversation convo;

    public QuestionEvent questionEvent;

    public int distortionLevel;
    public int activeLineIndex = 0;

    private bool conversationStarted = false;
    private bool makingDecision = false;
    private GameObject distortionManager;
    private GameObject uiController;

    //public Canvas ui;

    // public Button nextButton;

    // public Image portrait;
    // public TMP_Text characterName;

    // public GameObject characterBubble;
    // public TMP_Text characterDialogue;

    // public GameObject playerBubble;
    // public TMP_Text playerDialogue;

    // public GameObject decUI;

    // public Character chara;

    // private ParticleSystem[] activeParticles;
    // private Image[] activeVignettes;

    // Start is called before the first frame update
    void Awake()
    {
        distortionManager = GameObject.Find("DistortionManager");
        uiController = GameObject.Find("UIController");
        // playerBubble.SetActive(false);
        // playerDialogue.text = "";
        // characterBubble.SetActive(false);
        // characterDialogue.text = "";
        // decUI.SetActive(false);

        // Initialize Active Systems to empty
        // activeParticles = new ParticleSystem[0];
        // activeVignettes = new Image[0];

        // ui.enabled = false;
    }

    // Update is called once per frame
    // void Update()
    // {
    //   if (!makingDecision){
    //     if (Input.GetKeyDown("space"))
    //     {
    //       AdvanceConversation();
    //     }
    //   }
    // }

    // This function progresses the conversation upon click or space bar; made public so a button can be implemented
    public void AdvanceConversation()
    {
        // If there's a question, show question
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
      if (!makingDecision) {
        // Get next line if possible
        // If possible
          // Check character name for player
          // If player
            // Check if thought
            // If thought
              // updateThoughtLine with text
              // Show player thought bubble, hide everything else
            // else
              // updatePlayerLine with text
              // Show plauer dialogue bubble, hide everything else
          // Else
            // Update character line
            // Check to see if it contains shadowText
              // If yes, update Shadow Line
            // Show character bubble, hide everything else
            // Show shadow bubble; UI controller would know whether or not to
        // If there are more lines to read...
        if (activeLineIndex < convo.lines.Length)
        {
            Line currentLine = convo.lines[activeLineIndex];
            // Show relevant character
            distortionManager.SendMessage("UpdateCurrentCharacter", currentLine.character);

              // In order to pick correct, inspect line
                // If line character is player, show player bubble
                // if line character is playerThoughts, show player thought bubble
                // if line character is character, show character speech bubble
                // if line character is character && is Shadow thought is true, show shadow bubble
                // Send line As-Is
            if(currentLine.character.characterName == "Player"){
              uiController.SendMessage("showPlayerBubble");
              uiController.SendMessage("updatePlayerLine", currentLine.text);
            } else if (currentLine.character.characterName == "PlayerThoughts") {
              uiController.SendMessage("showPlayerThoughtBubble");
              uiController.SendMessage("updateThoughtLine", currentLine.text);
            } else {
              uiController.SendMessage("showCharacterBubble");
              if (currentLine.altDialogue && currentLine.character.hasMetBefore){
                  uiController.SendMessage("updateCharacterLine", currentLine.altText);
              } else {
                uiController.SendMessage("updateCharacterLine", currentLine.text);
              }
              if (currentLine.shadowDialogue){
                uiController.SendMessage("showShadowBubble");
                uiController.SendMessage("updateShadowLine", currentLine.shadowText);
              }
            }

            // set the conversation to started...
            // conversationStarted = true;
            // and read the next line
            // DisplayLine();
            activeLineIndex += 1;

            // show the speaker UI
            // ui.enabled = true;
        }

        else
        {
            // No more lines to read; is a question present?
            // if so, present it to the player
            if (convo.decision != null){
              // ui.enabled = false;
              // Turn on Decision UI
              // decUI.SetActive(true);
              // Turn off Character UIs
              // playerBubble.SetActive(false);
              // characterBubble.SetActive(false);
              // portrait.enabled = false;
              uiController.SendMessage("showDecisionUI", convo.decision);
              disableNextInput();

              // decUI.SendMessage("Change", convo.decision);
            }
            // hide the speaker UI
            //ui.enabled = false;
        }
      }
    }

    void disableNextInput(){
      // nextButton.gameObject.SetActive(false);
      makingDecision = true;
    }

    void enableNextInput(){
      // nextButton.gameObject.SetActive(true);
      makingDecision = false;
    }

    // public void updatePortrait(Sprite nextPortrait){
      // portrait.sprite = nextPortrait;
    // }

    // public void updateActiveParticleSystems(ParticleSystem[] newParticleSystems){
        // Disable all existing Particle Systems
        // for(int i = 0; i < activeParticles.Length; i++){
          // activeParticles[i].Stop();
        // }

        // Set active to new active list
        // activeParticles = newParticleSystems;

        // Enable all new particle systems
        // for(int x = 0; x < activeParticles.Length; x++){
          // activeParticles[x].Play();
        // }
    // }

    // public void updateActiveVignettes(Image[] newVignettes){
        // Disable current Images
        // for(int j = 0; j < activeVignettes.Length; j++){
          // activeVignettes[j].enabled = false;
        // }

        // Set active to new list
        // activeVignettes = newVignettes;

        // Enable New vignettes
        // for(int z = 0; z < activeVignettes.Length; z++){
          // activeVignettes[z].enabled = true;
        // }
    // }

    // Updates text and bubbles to correspond to current line in convo and advances activeLineIndex to next line
    // void DisplayLine()
    // {
        // Line line = convo.lines[activeLineIndex];
        // Character character = line.character;
        // distortionManager.SendMessage("UpdateCurrentCharacter", character);
        // portrait.enabled = true;

        // portrait.sprite = line.character.characterSprites[distortionLevel];

        // if (character.isPlayer)
        // {
            // playerBubble.SetActive(true);
            // characterBubble.SetActive(false);
            // playerDialogue.text = line.text.ToString();
        // }
        // else if (!character.isPlayer)
        // {
            // playerBubble.SetActive(false);
            // characterBubble.SetActive(true);
            // characterDialogue.text = line.text.ToString();
        // }
        // else
        // {
            // playerBubble.SetActive(false);
            // characterBubble.SetActive(false);
        // }

        // characterName.text = line.character.characterName;
    // }

    public void AdvanceLine()
    {
        // if there is no conversation, do nothing
        if (convo == null) return;

        // If the conversation has not started, start the conversation
        if (!conversationStarted) Initialize();

        // If there are more lines to read, read next line
        // if (activeLineIndex < convo.lines.Length)
            // DisplayLine();

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
        // decUI.SetActive(false);
        uiController.SendMessage("hideDecisionUI");
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
