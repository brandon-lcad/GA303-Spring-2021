using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager_Hikari : MonoBehaviour
{
    public Canvas ui;

    public Image portrait;
    public TMP_Text characterName;
    public TMP_Text dialogue;

    private bool uiActive;

    public Character chara;
    public Conversation convo;
    public Conversation choice;
    public bool choosing;

    public int distortionLevel;
    private int activeLineIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        ui.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (choosing == true)
        {
            PlayerChoice();
        }
        else if (Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
    }

    // This function progresses the conversation upon click or space bar; made public so a button can be implemented
    public void AdvanceConversation()
    {
        // If there are more lines to read...
        if (activeLineIndex < convo.lines.Length && characterName != null)
        {
            // read the next line
            DisplayLine();
            activeLineIndex += 1;

            ui.enabled = true;
        }
        //else
        //{
            // convo == choice;
            // hide the speaker UI
            //ui.enabled == false;

            // if (choice == null)
                // {
                   // Go back to menu screen
                // }

        //}
    }

    public void PlayerChoice()
    {

    }

    void DisplayLine()
    {
        Line line = convo.lines[activeLineIndex];
        Character character = line.character;

        characterName.text = line.character.characterName;
        portrait.sprite = line.character.characterSprites[distortionLevel];

        dialogue.text = line.text.ToString();
    }

}
