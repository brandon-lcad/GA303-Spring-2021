using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public Canvas ui;
    // Background Image
    // public Image bg;
    // Next Button
    public GameObject nextButton;
    // Distortion Animation - type tbd
    private ParticleSystem[] activeParticles;
    // Distortion vignettes
    private Image[] activeVignettes;
    // Character Portrait and Shadow Portrait
    public Image portrait;
    public Image shadowPortrait;
    // private TMP_Text characterName;
    // Character Speech Bubble
    public GameObject characterBubble;
    public TMP_Text characterDialogue;
    // Distortion Shadow Thought Bubble
    public GameObject distortionBubble;
    public TMP_Text distortionDialogue;
    // Player Speech Bubble
    public GameObject playerBubble;
    public TMP_Text playerDialogue;
    // Player Thought Bubble
    public GameObject thoughtBubble;
    public TMP_Text thoughtDialogue;

    private bool mindReading;

    public GameObject decUI;

    public static UIController Instance;

    private GameObject distortionManager;
    private GameObject dialogueManager;

    public string currentShadowLine;
    public string currentOtherLine;


    // public Animator fadeAnimator;

    // public Character chara;
    // public Conversation convo;

    // public QuestionEvent questionEvent;

    // public int distortionLevel;
    // private int activeLineIndex = 0;

    // private bool conversationStarted = false;
    // private bool makingDecision = false;
    // private GameObject distortionManager;

    // Start is called before the first frame update
    void Awake()
    {
      // Don't Destroy this object on new scene
      if (Instance == null)
      {
          DontDestroyOnLoad(gameObject);
          Instance = this;
      }
      else if (Instance != this)
      {
          Destroy(gameObject);
      }

        // Sets all speech / thought bubbles off
        characterBubble.SetActive(false);
        characterDialogue.text = "";
        distortionBubble.SetActive(false);
        distortionDialogue.text = "";
        playerBubble.SetActive(false);
        playerDialogue.text = "";
        thoughtBubble.SetActive(false);
        thoughtDialogue.text = "";
        mindReading = false;
        hidePortraits();
        // Sets decision UI canvas off
        decUI.SetActive(false);

        distortionManager = GameObject.Find("DistortionManager");
        dialogueManager = GameObject.Find("DialogueManager");
        // Initialize Active Systems to empty
        activeParticles = new ParticleSystem[0];
        activeVignettes = new Image[0];
        // Shows next button on screen
        nextButton.SetActive(true);

        ui.enabled = true;
    }

    // Update is called once per frame
    // void Update()
    // {
      // if (!makingDecision){
        // if (Input.GetKeyDown("space"))
        // {
        // AdvanceConversation();
        // }
      // }
    // }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
          if (characterBubble.active)
          {
            if (characterDialogue.text != currentOtherLine)
              {
                currentOtherLine = characterDialogue.text;
              }
            else
              {
                sendAdvanceConversation();
              }
          }

          else if (playerBubble.active)
          {
            if (playerDialogue.text != currentOtherLine)
              {
                currentOtherLine = playerDialogue.text;
              }
            else
              {
                sendAdvanceConversation();
              }
          }

          else if (thoughtBubble.active)
          {
            if (thoughtDialogue.text != currentOtherLine)
              {
                currentOtherLine = thoughtDialogue.text;
              }
            else
              {
                sendAdvanceConversation();
              }
          }

          else if (distortionBubble.active)
          {
              if (distortionDialogue.text != currentShadowLine)
              {
                currentShadowLine = distortionDialogue.text;
              }
            else
              {
                sendAdvanceConversation();
              }
          }

          else
          {
          sendAdvanceConversation();
          }
       }
    }

    public void sendAdvanceConversation(){
        dialogueManager.SendMessage("AdvanceConversation");
    }

    // This function progresses the conversation upon click or space bar; made public so a button can be implemented
    // public void AdvanceConversation()
    // {
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
        // if (activeLineIndex < convo.lines.Length)
        // {
            // set the conversation to started...
            // conversationStarted = true;
            // and read the next line
            // DisplayLine();
            // activeLineIndex += 1;

            // show the speaker UI
            //ui.enabled = true;
        // }

        // else
        // {
            // No more lines to read; is a question present?
            // if so, present it to the player
            // if (convo.decision != null){
              // ui.enabled = false;
              // Turn on Decision UI
              // decUI.SetActive(true);
              // Turn off Character UIs
              // playerBubble.SetActive(false);
              // distortionBubble.SetActive(false);
              // characterBubble.SetActive(false);
              // thoughtBubble.SetActive(false);
              // portrait.enabled = false;
              // Turn off next button
              // nextButton.SetActive(false);
              // disableNextInput();

              // decUI.SendMessage("Change", convo.decision);
            // }
            // hide the speaker UI
            //ui.enabled = false;
        // }
    // }

    // void disableNextInput(){
      // nextButton.gameObject.SetActive(false);
      // makingDecision = true;
    // }

    // void enableNextInput(){
      // nextButton.gameObject.SetActive(true);
      // makingDecision = false;
    // }

    public void updatePortrait(Sprite nextPortrait){
      portrait.enabled = true;
      portrait.sprite = nextPortrait;
      }

    public void updateShadowPortrait(Sprite nextShadow){
      shadowPortrait.enabled = true;
      shadowPortrait.sprite = nextShadow;
    }

    public void updateMindReading(bool isMindReading){
      mindReading = isMindReading;
      // if (!mindReading){
      //   distortionBubble.SetActive(false);
      // }
    }

    public void updateActiveParticleSystems(ParticleSystem[] newParticleSystems){
        // Disable all existing Particle Systems
        for(int i = 0; i < activeParticles.Length; i++){
          activeParticles[i].Stop();
        }

        // Set active to new active list
        activeParticles = newParticleSystems;

        // Enable all new particle systems
        for(int x = 0; x < activeParticles.Length; x++){
          activeParticles[x].Play();
        }
    }

    public void updateActiveVignettes(Image[] newVignettes){
        // Disable current Images
        for(int j = 0; j < activeVignettes.Length; j++){
          activeVignettes[j].enabled = false;
        }

        // Set active to new list
        activeVignettes = newVignettes;

        // Enable New vignettes
        for(int z = 0; z < activeVignettes.Length; z++){
          activeVignettes[z].enabled = true;
        }
    }

    public void updateCharacterLine(string characterLine){
        // characterDialogue.text = characterLine;
        currentOtherLine = characterLine;
        characterDialogue.text = "";
        StopCoroutine(EffectTypeWriter(characterLine, characterDialogue));
        StartCoroutine(EffectTypeWriter(characterLine, characterDialogue));
        // if (characterDialogue.text == characterLine){
        //   StopCoroutine(EffectTypeWriter(characterLine, characterDialogue));
        // }
    }

    public void updateShadowLine(string shadowLine){
        // distortionDialogue.text = shadowLine;
        currentShadowLine = shadowLine;
        distortionDialogue.text = "";
        StopCoroutine(EffectTypeWriter(shadowLine, distortionDialogue));
        StartCoroutine(EffectTypeWriter(shadowLine, distortionDialogue));
        // if (distortionDialogue.text == shadowLine){
        // //   StopCoroutine(EffectTypeWriter(shadowLine, distortionDialogue));
        // }
    }

    public void updatePlayerLine(string playerLine){
        // playerDialogue.text = playerLine;
        currentOtherLine = playerLine;
        playerDialogue.text = "";
        StopCoroutine(EffectTypeWriter(playerLine, playerDialogue));
        StartCoroutine(EffectTypeWriter(playerLine, playerDialogue));
        // playerDialogue.text = playerLine;
        // if (playerDialogue.text == playerLine){
        //   StopCoroutine(EffectTypeWriter(playerLine, playerDialogue));
        // }
    }

    public void updateThoughtLine(string thoughtLine){
        // thoughtDialogue.text = thoughtLine;
        currentOtherLine = thoughtLine;
        thoughtDialogue.text = "";
        StopCoroutine(EffectTypeWriter(thoughtLine, thoughtDialogue));
        StartCoroutine(EffectTypeWriter(thoughtLine, thoughtDialogue));
        // if (thoughtDialogue.text == thoughtLine){
        // //   StopCoroutine(EffectTypeWriter(thoughtLine, thoughtDialogue));
      }

    // Typewrite effects for dialogue and thought lines
    private IEnumerator EffectTypeWriter(string whateverLine, TMP_Text lineType){
      foreach(char character in whateverLine.ToCharArray())
          {
            lineType.text += character;
            // yield return new WaitForSeconds(0.04f);
            yield return null;
          }

      }

    public void showCharacterBubble(){
        characterBubble.SetActive(true);
        distortionBubble.SetActive(false);
        playerBubble.SetActive(false);
        thoughtBubble.SetActive(false);
    }

    public void showPlayerBubble(){
      characterBubble.SetActive(false);
      distortionBubble.SetActive(false);
      playerBubble.SetActive(true);
      thoughtBubble.SetActive(false);
    }

    public void showPlayerThoughtBubble(){
      characterBubble.SetActive(false);
      distortionBubble.SetActive(false);
      playerBubble.SetActive(false);
      thoughtBubble.SetActive(true);
    }

    public void showShadowBubble(){
        if (mindReading){
          distortionBubble.SetActive(true);
        }
    }

    public void showDecisionUI(Decision nextDecision){
      // Turn everything off
      characterBubble.SetActive(false);
      characterDialogue.text = "";
      distortionBubble.SetActive(false);
      distortionDialogue.text = "";
      playerBubble.SetActive(false);
      playerDialogue.text = "";
      thoughtBubble.SetActive(false);
      thoughtDialogue.text = "";
      nextButton.SetActive(false);
      hidePortraits();

      // Turn on Decision UI
      decUI.SetActive(true);

      decUI.SendMessage("Change", nextDecision);
    }

    public void hideDecisionUI(){
      // Turn off Decision UI
      decUI.SetActive(false);
      nextButton.SetActive(true);
      showPortraits();
    }

    private void showPortraits(){
      // Enable Portrait
      portrait.enabled = true;
      shadowPortrait.enabled = true;
    }

    private void hidePortraits(){
      // Hide Portrait
      shadowPortrait.enabled = false;
      portrait.enabled = false;
    }

    public void LoadScene(string sceneName){
      if (sceneName == ""){
        Debug.Log("No Scene to Load");
      }
      else
      {
        StartCoroutine(WaitTime(sceneName));
      }
    }

    private IEnumerator WaitTime(string sceneName){
      GameObject fadeScreen = GameObject.Find("BlackScreen");
      Debug.Log(fadeScreen);
      Animator animScreen = fadeScreen.GetComponent<Animator>();
      Debug.Log(animScreen);
      if (animScreen != null){
        characterBubble.SetActive(false);
        distortionBubble.SetActive(false);
        playerBubble.SetActive(false);
        thoughtBubble.SetActive(false);
        hidePortraits();
        animScreen.SetTrigger("FadeIn");
      }
      yield return new WaitForSeconds(1);
      SceneManager.LoadScene(sceneName);
      if (animScreen != null){
        animScreen.SetTrigger("FadeIn");
      }
    }
}
    // Updates text and bubbles to correspond to current line in convo and advances activeLineIndex to next line
    // void DisplayLine(int activeLineIndex)
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

    // public void AdvanceLine()
    // {
        // if there is no conversation, do nothing
        // if (convo == null) return;

        // If the conversation has not started, start the conversation
        // if (!conversationStarted) Initialize();

        // If there are more lines to read, read next line
        // if (activeLineIndex < convo.lines.Length)
            // DisplayLine();

        // If there aren't more lines to read, check for next conversation
        // else AdvanceConversation();
    // }

    // void Initialize()
    // {
        // conversationStarted = true;
        // activeLineIndex = 0;
    // }

    // Listens for ConversationChangeEvent and changes Conversation accordingly
    // public void ChangeConversation(Conversation nextConvo)
    // {
        // convo = nextConvo;
        // activeLineIndex = 0;
        // decUI.SetActive(false);
        // enableNextInput();
        // AdvanceConversation();
    // }

    //
    // void EndConversation()
    // {
        // convo = null;
        // conversationStarted = false;
    // }

    //private void SetDialogue(
    //    SpeakerUI activeSpeakerUI,
    //    SpeakerUI inactiveSpeakerUI,
    //    string text)
    //{
    //    activeSpeakerUI.Dialogue = text;
    //    activeSpeakerUI.Show();
    //    inactiveSpeakerUI.Hide();
    //}
